namespace HeroArchitect.Web.Domain.Events;

public class TurnEndEvent : IEvent
{
    public TurnEndEvent(Guid playerId, int order)
    {
        PlayerId = playerId;
    }

    public Guid PlayerId { get; }
}