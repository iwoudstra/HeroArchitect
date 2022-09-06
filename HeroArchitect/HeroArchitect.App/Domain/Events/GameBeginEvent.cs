namespace HeroArchitect.App.Domain.Events;

public class GameBeginEvent : IEvent
{
    public GameBeginEvent(ResourceSet beginResources)
    {
        BeginResources = beginResources;
    }

    public Guid PlayerId => Guid.Empty;
    public ResourceSet BeginResources { get; }
}