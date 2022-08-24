namespace HeroArchitect.Web.Domain.Events;

public interface IEvent
{
    public Guid PlayerId { get; }
}