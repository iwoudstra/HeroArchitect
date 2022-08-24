using HeroArchitect.Web.Domain.Exceptions;

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
    public SpecialUnit? CurrentSpecialUnit { get; internal set; }
    public ResourceSet Resources { get; private set; } = ResourceSet.Empty;

    internal void SetInitialResources(ResourceSet beginResources)
    {
        if (Resources != ResourceSet.Empty)
        {
            throw new LogicException($"{ nameof(SetInitialResources) } called but players resources aren't empty!");
        }

        Resources = beginResources;
    }
}