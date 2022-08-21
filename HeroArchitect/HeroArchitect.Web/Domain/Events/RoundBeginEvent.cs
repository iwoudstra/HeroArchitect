namespace HeroArchitect.Web.Domain.Events;

public class RoundBeginEvent : IDerivedEvent
{
    public RoundBeginEvent(Guid playerId, int order)
    {
        PlayerId = playerId;
        Order = order;
    }

    public Guid PlayerId { get; }
    public int Order { get; }
}