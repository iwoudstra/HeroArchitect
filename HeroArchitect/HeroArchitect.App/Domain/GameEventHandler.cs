using HeroArchitect.App.Domain.EventHandlers;
using HeroArchitect.App.Domain.Events;

namespace HeroArchitect.App.Domain;

public class GameEventHandler : IEventHandler<IEvent>
{
    private static Dictionary<Type, IEventHandler<IEvent>> eventHandlers = new Dictionary<Type, IEventHandler<IEvent>>();

    static GameEventHandler()
    {
        InitializeGenericCache();

        void InitializeGenericCache()
        {
            if (!eventHandlers.Any())
            {
                var genericType = typeof(IEventHandler<>);
                var implementationTypes = typeof(GameEventHandler).Assembly
                    .GetTypes()
                    .Where(x => x.GetInterfaces().Any(y => y.IsGenericType
                        && y.GetGenericTypeDefinition() == genericType
                        && y.GenericTypeArguments.FirstOrDefault()?.IsAssignableTo(typeof(IEvent)) == true
                        && y.GenericTypeArguments.FirstOrDefault() != typeof(IEvent)));

                foreach (var implementationType in implementationTypes)
                {
                    var eventType = implementationType.GetInterfaces()[0].GetGenericArguments()[0];
                    var handlerInstance = Activator.CreateInstance(implementationType);

                    var delegateType = typeof(EventHandlerDelegate<>);
                    var delegateInstance = Activator.CreateInstance(delegateType.MakeGenericType(eventType), handlerInstance) as IEventHandler<IEvent>;

                    if (delegateInstance is not null)
                    {
                        eventHandlers.Add(eventType, delegateInstance);
                    }
                }
            }
        }
    }

    public void Handle(Game game, IEvent _event)
    {
        eventHandlers[_event.GetType()].Handle(game, _event);
    }

    public bool IsAllowed(Game game, IEvent _event)
    {
        return eventHandlers[_event.GetType()].IsAllowed(game, _event);
    }
}