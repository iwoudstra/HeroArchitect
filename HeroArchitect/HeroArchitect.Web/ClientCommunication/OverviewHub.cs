using HeroArchitect.Web.Domain;
using HeroArchitect.Web.Domain.FrontendCommunication;
using HeroArchitect.Web.Domain.State;
using Microsoft.AspNetCore.SignalR;

namespace HeroArchitect.Web.ClientCommunication;

public class OverviewHub : BaseHub
{
    public OverviewHub(IStateContainer stateContainer, ISessionContainer sessionContainer)
        : base(stateContainer, sessionContainer)
    {
    }

    public async Task GetState()
    {
        await SendState();
    }

    public async Task SetName(string name)
    {
        _sessionContainer.State.User.Name = name;

        await SendState();
    }

    private async Task SendState()
    {
        await Clients.Caller.SendAsync("ReceiveMessage", new GameMessage<User>("stateChanged", _sessionContainer.State.User));
    }
}