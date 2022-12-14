namespace HeroArchitect.Web.Domain.Events;

public class RoundBeginEvent : IDerivedEvent
{
    public RoundBeginEvent(Guid playerId)
    {
        PlayerId = playerId;
    }

    public Guid PlayerId { get; }
}