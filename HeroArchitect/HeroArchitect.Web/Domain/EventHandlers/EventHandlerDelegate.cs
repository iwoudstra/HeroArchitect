using HeroArchitect.Web.Domain.Events;

namespace HeroArchitect.Web.Domain.EventHandlers;

public class EventHandlerDelegate<T> : IEventHandler<IEvent>
    where T : IEvent
{
    private readonly IEventHandler<T> _eventHandler;

    public EventHandlerDelegate(IEventHandler<T> eventHandler)
    {
        _eventHandler = eventHandler;
    }

    public void Handle(Game game, IEvent _event)
    {
        _eventHandler.Handle(game, (T)_event);
    }

    public bool IsAllowed(Game game, IEvent _event)
    {
        return _eventHandler.IsAllowed(game, (T)_event);
    }
}