namespace HeroArchitect.Web.Domain.Events;

public class RoundEndEvent : IEvent
{
    public RoundEndEvent(Guid playerId, int order)
    {
        PlayerId = playerId;
        Order = order;
    }

    public Guid PlayerId { get; }
    public int Order { get; }
}