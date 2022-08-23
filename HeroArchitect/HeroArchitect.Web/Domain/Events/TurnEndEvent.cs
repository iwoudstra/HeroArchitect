namespace HeroArchitect.Web.Domain.Events;

public class TurnEndEvent : IEvent
{
    public TurnEndEvent(Guid playerId, int order)
    {
        PlayerId = playerId;
        Order = order;
    }

    public Guid PlayerId { get; }
    public int Order { get; }
}