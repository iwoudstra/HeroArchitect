using HeroArchitect.App.Domain.Events;

namespace HeroArchitect.App.Domain.EventHandlers;

public class SpecialUnitDecisionEventHandler : IEventHandler<SpecialUnitDecisionEvent>
{
    public void Handle(Game game, SpecialUnitDecisionEvent _event)
    {
        var player = game.GetPlayer(_event.PlayerId);
        player.CurrentSpecialUnit = _event.SpecialUnit;
    }

    public bool IsAllowed(Game game, SpecialUnitDecisionEvent _event)
    {
        return !game.Players.Any(x => x.CurrentSpecialUnit == _event.SpecialUnit);
    }
}