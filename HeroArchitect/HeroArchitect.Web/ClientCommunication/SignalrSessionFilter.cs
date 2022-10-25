using HeroArchitect.Web.Domain.State;
using Microsoft.AspNetCore.SignalR;

namespace HeroArchitect.Web.ClientCommunication;

public class SignalrSessionFilter : IHubFilter
{
    private readonly ISessionContainer _sessionContainer;

    public SignalrSessionFilter(ISessionContainer sessionContainer)
    {
        _sessionContainer = sessionContainer;
    }

    public async ValueTask<object?> InvokeMethodAsync(HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<object?>> next)
    {
        try
        {
            var reference = invocationContext.Context.ConnectionId;
            _sessionContainer.RetrieveState(reference);
        }
        catch
        {
        }

        return await next(invocationContext);
    }

    public Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
    {
        return next(context);
    }

    public Task OnDisconnectedAsync(HubLifetimeContext context, Exception? exception, Func<HubLifetimeContext, Exception?, Task> next)
    {
        return next(context, exception);
    }
}