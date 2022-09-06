using HeroArchitect.Web.Domain.State;
using Microsoft.AspNetCore.SignalR;

namespace HeroArchitect.Web.ClientCommunication;

public class GameHub : Hub
{
    private IStateContainer _stateContainer;
    private ISessionContainer _sessionContainer;

    public GameHub(IStateContainer stateContainer, ISessionContainer sessionContainer)
    {
        _stateContainer = stateContainer;
        _sessionContainer = sessionContainer;
    }


}