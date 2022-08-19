namespace HeroArchitect.Web.Domain.Events;

public interface IEvent
{
    public Guid PlayerId { get; }
    public int Order { get; }
}