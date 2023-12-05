
using CounterStrikeSharp.API.Modules.Utils;

namespace SuperheroPlugin;

public static class StringResources
{
    public static string LevelStatsMessage(
        int level, int currXp, int lvlUpXp, int abilityPoints) =>
        $@"Level {ChatColors.Purple}{level}{ChatColors.Default} | Exp {ChatColors.Blue}{currXp}/{lvlUpXp}{ChatColors.Default} | AP {ChatColors.Green}{abilityPoints}{ChatColors.Default}";

    public static string GainedXp(int xpAmount) =>
        $@" {ChatColors.Blue}+{xpAmount}xp{ChatColors.Default} Gained";

    public static string GainedLevel(int newLevel, int newApPoints) =>
        $@"You reached Level {ChatColors.Purple}{newLevel}{ChatColors.Default} | You have {ChatColors.Green}{newApPoints}{ChatColors.Default} AP";

    public static string NotEnoughAp() =>
        $@"You don't have enough {ChatColors.Green}AP{ChatColors.Default}";

    public static string AbilityOption(int level, string abilityName) =>
        $@"Level:{ChatColors.Purple}{level}{ChatColors.Default} | {abilityName}";

    public static string AddedAbility(string abilityName) =>
        $@"Added ability {ChatColors.Green}{abilityName}{ChatColors.Default}";
}
