using HeroArchitect.Web.Domain.Exceptions;

namespace HeroArchitect.Web.Domain;

public class Player
{
    public Player(Guid id, Guid playerId, string name)
    {
        Id = id;
        PlayerId = playerId;
        Name = name;
    }

    public Guid Id { get; }
    public Guid PlayerId { get; }
    public string Name { get; private set; }
    public SpecialUnitType? CurrentSpecialUnit { get; internal set; }
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