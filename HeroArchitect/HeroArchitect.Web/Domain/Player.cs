namespace HeroArchitect.Web.Domain;

public class Player
{
    public Player(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; private set; }
    public SpecialUnit? CurrentSpecialUnit { get; private set; }
}