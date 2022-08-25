using HeroArchitect.Web.Domain.Events;

namespace HeroArchitect.Web.Domain.EventHandlers;

public class TurnEndEventHandler : IEventHandler<TurnEndEvent>
{
    public void Handle(Game game, TurnEndEvent _event)
    {
        var nextPlayer = game.GetNextTurnPlayer();
        if (nextPlayer is null)
        {
            game.HandleEvent(new RoundBeginEvent(Guid.Empty));
        }
        else
        {
            // notify player?
        }
    }

    public bool IsAllowed(Game game, TurnEndEvent _event)
    {

        return true;
    }
}