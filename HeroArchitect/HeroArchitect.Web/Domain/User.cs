namespace HeroArchitect.Web.Domain;

public class User : IEquatable<User?>
{
    public User(Guid id, string name)
    {
        Id = id;
        Name = string.IsNullOrEmpty(name) ? $"player-{ id.ToString().Substring(24) }" : name;
    }

    public Guid Id { get; }
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as User);
    }

    public bool Equals(User? other)
    {
        return other is not null && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(User? left, User? right)
    {
        return EqualityComparer<User>.Default.Equals(left, right);
    }

    public static bool operator !=(User? left, User? right)
    {
        return !(left == right);
    }
}