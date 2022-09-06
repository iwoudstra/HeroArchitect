using HeroArchitect.App.Domain;

namespace HeroArchitect.App.Domain.Events;

public class SpecialUnitDecisionEvent : IEvent
{
    public SpecialUnitDecisionEvent(Guid playerId, SpecialUnit specialUnit)
    {
        PlayerId = playerId;
        SpecialUnit = specialUnit;
    }

    public Guid PlayerId { get; set; }
    public SpecialUnit SpecialUnit { get; set; }
}