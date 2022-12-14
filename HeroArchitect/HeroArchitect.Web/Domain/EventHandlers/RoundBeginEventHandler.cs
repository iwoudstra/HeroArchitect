using HeroArchitect.Web.Domain.Events;

namespace HeroArchitect.Web.Domain.EventHandlers;

public class RoundBeginEventHandler : IEventHandler<RoundBeginEvent>
{
    public void Handle(Game game, RoundBeginEvent _event)
    {
        // do round begin resource stuff.
    }

    public bool IsAllowed(Game game, RoundBeginEvent _event)
    {
        return true;
    }
}