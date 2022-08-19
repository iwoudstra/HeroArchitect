namespace HeroArchitect.Web.Domain.Events;

public class SpecialUnitDecisionEvent : IEvent
{
    public SpecialUnitDecisionEvent(Guid playerId, int order, SpecialUnit specialUnit)
    {
        PlayerId = playerId;
        Order = order;
        SpecialUnit = specialUnit;
    }

    public Guid PlayerId { get; set; }
    public int Order { get; set; }
    public SpecialUnit SpecialUnit { get; set; }
}