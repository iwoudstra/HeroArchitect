using HeroArchitect.App.Domain;
using HeroArchitect.App.Domain.Events;

namespace HeroArchitect.App.Domain.EventHandlers;

public interface IEventHandler<T>
    where T : IEvent
{
    public void Handle(Game game, T _event);
    public bool IsAllowed(Game game, T _event);
}