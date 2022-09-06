namespace HeroArchitect.Web.Domain.State;

public class SessionContainer : ISessionContainer
{
    public User User { get; } = new User(Guid.NewGuid(), string.Empty);
}