using HeroArchitect.Web.Domain.Events;

namespace HeroArchitect.Web.Domain.EventHandlers;

public class TurnEndEventHandler : IEventHandler<TurnEndEvent>
{
    public void Handle(Game game, TurnEndEvent _event)
    {
        var nextPlayer = game.GetNextTurnPlayer();
        if (nextPlayer is null)
        {
            game.HandleEvent(new RoundEndEvent(Guid.Empty, game.NextEventOrder));
        }
        else
        {
            // notify player?
        }
    }
}