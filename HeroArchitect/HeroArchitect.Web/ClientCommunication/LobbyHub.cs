using HeroArchitect.Web.Domain;
using HeroArchitect.Web.Domain.FrontendCommunication;
using HeroArchitect.Web.Domain.State;
using Microsoft.AspNetCore.SignalR;

namespace HeroArchitect.Web.ClientCommunication;

public class LobbyHub : Hub
{
    private IStateContainer _stateContainer;
    private ISessionContainer _sessionContainer;

    public LobbyHub(IStateContainer stateContainer, ISessionContainer sessionContainer)
    {
        _stateContainer = stateContainer;
        _sessionContainer = sessionContainer;
    }

    public async Task GetState()
    {
        await SendState();
    }

    public async Task JoinLobby(Guid lobbyId)
    {
        _stateContainer.JoinLobby(lobbyId, _sessionContainer.User);

        await SendState();
    }

    public async Task CreateLobby(string name, int maxPlayerCount)
    {
        var lobby = _stateContainer.CreateLobby(name, maxPlayerCount);

        await JoinLobby(lobby.Id);
    }

    private async Task SendState()
    {
        await Clients.Caller.SendAsync("ReceiveMessage", new GameMessage<IReadOnlyCollection<Lobby>>("stateChanged", _stateContainer.Lobbies));
    }
}