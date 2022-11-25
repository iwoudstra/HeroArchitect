namespace HeroArchitect.Web.Domain.Database;

public class ActionStrength
{
    public ActionStrength(ActionType actionType, int strength)
    {
        ActionType = actionType;
        Strength = strength;
    }

    public ActionType ActionType { get; }
    public int Strength { get; }
}