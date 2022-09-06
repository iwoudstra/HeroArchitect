﻿namespace HeroArchitect.App.Domain;

public readonly struct ResourceSet
{
    public ResourceSet(int gold = 0, int actions = 0)
    {
        Gold = gold;
        Actions = actions;
    }

    public static ResourceSet operator -(ResourceSet a, ResourceSet b) => new ResourceSet(a.Gold - b.Gold, a.Actions - b.Actions);
    public static ResourceSet operator +(ResourceSet a, ResourceSet b) => new ResourceSet(a.Gold + b.Gold, a.Actions + b.Actions);
    public static bool operator ==(ResourceSet a, ResourceSet b) => a.Gold == b.Gold && a.Actions == b.Actions;
    public static bool operator !=(ResourceSet a, ResourceSet b) => a.Gold != b.Gold || a.Actions != b.Actions;

    public static ResourceSet Empty => new ResourceSet();

    public int Gold { get; init; }
    public int Actions { get; init; }

    public bool HasResourcesFor(ResourceSet requiredResources)
    {
        return Gold >= requiredResources.Gold && Actions >= requiredResources.Actions;
    }

    public override bool Equals(object? obj)
    {
        return obj is ResourceSet set &&
               Gold == set.Gold &&
               Actions == set.Actions;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Gold, Actions);
    }
}