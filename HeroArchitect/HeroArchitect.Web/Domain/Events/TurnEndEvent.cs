namespace HeroArchitect.Web.Domain.Events;

public class TurnEndEvent : IEvent
{
    public TurnEndEvent(Guid playerId, int order, Player player)
    {
        PlayerId = playerId;
        Order = order;
        Player = player;
    }

    public Guid PlayerId { get; }
    public int Order { get; }
    public Player Player { get; }
}