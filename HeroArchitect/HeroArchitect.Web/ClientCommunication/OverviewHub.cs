using HeroArchitect.Web.Domain.State;
using Microsoft.AspNetCore.SignalR;

namespace HeroArchitect.Web.ClientCommunication;

public class OverviewHub : Hub
{
    private IStateContainer _stateContainer;
    private ISessionContainer _sessionContainer;

    public OverviewHub(IStateContainer stateContainer, ISessionContainer sessionContainer)
    {
        _stateContainer = stateContainer;
        _sessionContainer = sessionContainer;
    }

    public void Register(string name)
    {
        _sessionContainer.User.Name = name;
    }
}