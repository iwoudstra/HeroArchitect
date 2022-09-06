using HeroArchitect.App.Domain;
using HeroArchitect.App.Domain.Events;

namespace HeroArchitect.App.Domain.EventHandlers;

public class GameBeginEventHandler : IEventHandler<GameBeginEvent>
{
    public void Handle(Game game, GameBeginEvent _event)
    {
        foreach (var player in game.Players)
        {
            player.SetInitialResources(_event.BeginResources);
        }
    }

    public bool IsAllowed(Game game, GameBeginEvent _event)
    {
        return true;
    }
}