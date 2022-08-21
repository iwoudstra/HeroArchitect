using HeroArchitect.Web.Domain.Events;

namespace HeroArchitect.Web.Domain.EventHandlers;

public interface IEventHandler<T>
    where T: IEvent
{
    public void Handle(Game game, T _event);
    public bool IsAllowed(Game game, T _event);
}