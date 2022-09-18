namespace HeroArchitect.Web.Domain.FrontendCommunication;

public class GameMessage<T>
{
    public GameMessage(string type, T message)
    {
        Type = type;
        Message = message;
    }

    public string Type { get; }
    public T Message { get; }
}