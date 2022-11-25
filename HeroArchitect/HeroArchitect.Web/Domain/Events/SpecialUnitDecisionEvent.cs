namespace HeroArchitect.Web.Domain.Events;

public class SpecialUnitDecisionEvent : IEvent
{
    public SpecialUnitDecisionEvent(Guid playerId, SpecialUnitType specialUnit)
    {
        PlayerId = playerId;
        SpecialUnit = specialUnit;
    }

    public Guid PlayerId { get; set; }
    public SpecialUnitType SpecialUnit { get; set; }
}