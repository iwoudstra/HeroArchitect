using HeroArchitect.Web.Domain;
using HeroArchitect.Web.Domain.Events;
using HeroArchitect.Web.Domain.Exceptions;
using HeroArchitect.Web.Domain.FrontendCommunication;
using HeroArchitect.Web.Domain.State;
using Microsoft.AspNetCore.SignalR;

namespace HeroArchitect.Web.ClientCommunication;

public class LobbyHub : BaseHub
{
    public LobbyHub(IStateContainer stateContainer, ISessionContainer sessionContainer)
        : base(stateContainer, sessionContainer)
    {
    }

    public async Task GetState()
    {
        await Clients.Caller.SendAsync("ReceiveMessage", new GameMessage<IReadOnlyCollection<Lobby>>("stateChanged", _stateContainer.Lobbies));
    }

    public async Task JoinLobby(Guid lobbyId)
    {
        var lobby = _stateContainer.JoinLobby(lobbyId, _sessionContainer.State.User);

        await Groups.AddToGroupAsync(Context.ConnectionId, lobby.Id.ToString());

        await Clients.All.SendAsync("ReceiveMessage", new GameMessage<Lobby>("lobbyChanged", lobby));
        await Clients.Caller.SendAsync("ReceiveMessage", new GameMessage<Lobby>("lobbyJoined", lobby));
    }

    public async Task LeaveLobby(Guid lobbyId)
    {
        var lobby = _stateContainer.LeaveLobby(lobbyId, _sessionContainer.State.User);

        if (lobby is null)
        {
            await Clients.All.SendAsync("ReceiveMessage", new GameMessage<Guid>("lobbyDeleted", lobbyId));
        }
        else
        {
            await Clients.All.SendAsync("ReceiveMessage", new GameMessage<Lobby>("lobbyChanged", lobby));
        }

        await Clients.Caller.SendAsync("ReceiveMessage", new GameMessage<Guid>("lobbyLeft", lobbyId));
    }

    public async Task CreateLobby(string name, int maxPlayerCount)
    {
        var lobby = _stateContainer.CreateLobby(_sessionContainer.State.User.Id, name, maxPlayerCount);

        await JoinLobby(lobby.Id);
    }

    public async Task KickUser(Guid lobbyId, Guid userId)
    {
        var lobby = _stateContainer.LeaveLobby(lobbyId, _sessionContainer.State.User);

        if (lobby is not null)
        {
            lobby.KickUser(userId);

            await Clients.All.SendAsync("ReceiveMessage", new GameMessage<Lobby>("lobbyChanged", lobby));
        }
    }

    public async Task StartGame(Guid lobbyId)
    {
        var lobby = _stateContainer.GetLobby(lobbyId);

        if (lobby.HostUserId != _sessionContainer.State.User.Id)
        {
            throw new GameException("Cannot start game, you are not the host.");
        }

        var game = _stateContainer.CreateGame(lobby);
        game.HandleEvent(new GameBeginEvent(new ResourceSet(3, 1)));

        await Clients.Group(lobby.Id.ToString()).SendAsync("ReceiveMessage", new GameMessage<Guid>("gameStarted", game.Id));
    }
}