namespace HeroArchitect.Web.Domain.State;

public class SessionState
{
    public User User { get; } = new User(Guid.NewGuid(), string.Empty);
}