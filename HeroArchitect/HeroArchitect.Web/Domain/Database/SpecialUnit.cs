using Microsoft.AspNetCore.Mvc.Formatters;

namespace HeroArchitect.Web.Domain.Database
{
    public class SpecialUnit
    {
        public static SpecialUnit Queen => new(SpecialUnitType.Queen, new List<ActionStrength> { new ActionStrength(ActionType.Recruit, 3), new ActionStrength(ActionType.Research, 2) }, new List<ActionType> { ActionType.Steal });
        public static SpecialUnit Thief => new(SpecialUnitType.Thief, new List<ActionStrength> { new ActionStrength(ActionType.Steal, 3) }, new List<ActionType> { ActionType.Recruit, ActionType.Work });
        public static SpecialUnit Fighter => new(SpecialUnitType.Fighter, new List<ActionStrength> { new ActionStrength(ActionType.Recruit, 3), new ActionStrength(ActionType.Fight, 3) }, new List<ActionType> { ActionType.Steal });
        public static SpecialUnit Banker => new(SpecialUnitType.Banker, new List<ActionStrength> { new ActionStrength(ActionType.Work, 4), new ActionStrength(ActionType.Sell, 2) }, new List<ActionType> { ActionType.Steal });
        public static SpecialUnit Builder => new(SpecialUnitType.Builder, new List<ActionStrength> { new ActionStrength(ActionType.Build, 3), new ActionStrength(ActionType.Sell, 2) }, new List<ActionType> { ActionType.Steal });
        public static SpecialUnit Magician => new(SpecialUnitType.Magician, new List<ActionStrength> { new ActionStrength(ActionType.Research, 3), new ActionStrength(ActionType.Build, 2) }, new List<ActionType> { ActionType.Steal });

        public SpecialUnit(SpecialUnitType specialUnitType, IReadOnlyList<ActionStrength> actionStrengths, IReadOnlyList<ActionType> forbiddenActions)
        {
            SpecialUnitType = specialUnitType;
            ActionStrengths = actionStrengths;
            ForbiddenActions = forbiddenActions;
        }

        public SpecialUnitType SpecialUnitType { get; }

        public IReadOnlyList<ActionStrength> ActionStrengths { get; }

        public IReadOnlyList<ActionType> ForbiddenActions { get; }
    }
}