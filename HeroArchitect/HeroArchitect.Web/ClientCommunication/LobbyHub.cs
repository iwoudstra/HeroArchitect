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

    public void JoinLobby(Guid lobbyId)
    {
        _stateContainer.JoinLobby(lobbyId, _sessionContainer.User);
    }
}