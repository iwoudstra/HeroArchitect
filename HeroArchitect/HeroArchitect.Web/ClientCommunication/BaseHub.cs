using HeroArchitect.Web.Domain.State;
using Microsoft.AspNetCore.SignalR;

namespace HeroArchitect.Web.ClientCommunication;

public abstract class BaseHub : Hub
{
    protected IStateContainer _stateContainer;
    protected ISessionContainer _sessionContainer;

    protected BaseHub(IStateContainer stateContainer, ISessionContainer sessionContainer)
    {
        _stateContainer = stateContainer;
        _sessionContainer = sessionContainer;
    }

    public async Task Register(string? identifier)
    {
        var playerId = identifier ?? Guid.NewGuid().ToString();

        _sessionContainer.Register(playerId, Context.ConnectionId);

        //
        await Clients.Caller.SendAsync("Registered", playerId);
    }
}