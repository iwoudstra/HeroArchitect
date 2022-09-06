using HeroArchitect.App.Domain;

namespace HeroArchitect.App.Domain.State;

public class Session
{
    public User User { get; } = new User(Guid.NewGuid(), string.Empty);
}