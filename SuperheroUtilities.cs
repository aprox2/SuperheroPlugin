using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;
using SuperheroPlugin.Abilities;

namespace SuperheroPlugin;

public static class SuperheroUtilities
{
    public static List<int> generateXpLevelCurve(int maxLevel)
    {
        int baseXp = 10;
        List<int> result = new List<int>();
        for (int level = 1; level <= maxLevel; level++) {
            result.Add((int) Math.Floor(baseXp * Math.Pow(level, 1.1f)));
        }
        return result;
    }


    public static void RefreshUI(SuperheroPlayer shPlayer)
    {
        if (shPlayer?.Player?.PlayerPawn?.Value == null) { return; }
        CCSPlayerPawn pawn = shPlayer.Player.PlayerPawn.Value;
        if (pawn.WeaponServices == null || pawn.ItemServices == null) { return; }
        string healthShot = "weapon_healthshot";

        VirtualFunctions.GiveNamedItem(pawn.ItemServices.Handle, healthShot, 0, 0, 0, 0);

        foreach (var wep in pawn.WeaponServices.MyWeapons)
        {
            if (wep?.IsValid == true && wep.Value?.IsValid == true &&
               !string.IsNullOrWhiteSpace(wep.Value.DesignerName) && wep.Value.DesignerName.Equals(healthShot))
            {
                wep.Value.Remove();
            }
        }
    }

    public static List<SuperheroAbility> filterExistingPlayerAbilities(List<SuperheroAbility> allAbilities, List<SuperheroAbility> playerAbilities)
    {
        return allAbilities
            .Where(ability => !playerAbilities.Any(playerAbility => playerAbility.abilityName == ability.abilityName))
            .ToList();
    }

    public static List<SuperheroAbility> filterMinimumLevelAbilities(List<SuperheroAbility> allAbilities, int playerLevel)
    {
        return allAbilities
            .Where(ability => playerLevel >= ability.minLevel)
            .ToList();
    }

    public static readonly string[] secondaryWeaponsList = new string[]{
        "weapon_glock",
        "weapon_elite",
        "weapon_p250",
        "weapon_tec9",
        "weapon_cz75a",
        "weapon_deagle",
        "weapon_revolver",
        "weapon_usp_silencer",
        "weapon_hkp2000",
        "weapon_fiveseven"
    };

}
