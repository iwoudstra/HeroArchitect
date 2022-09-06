namespace HeroArchitect.App.Domain.Events;

public interface IEvent
{
    public Guid PlayerId { get; }
}