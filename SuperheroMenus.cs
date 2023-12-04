using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Menu;
using SuperheroPlugin.Abilities;

namespace SuperheroPlugin;

public static class SuperheroMenus
{
    public static void generateAddAbilityMenu(CCSPlayerController? player, SuperheroPlugin shPlugin)
    {
        if (player == null) { return; }
        SuperheroPlayer shPlayer = shPlugin.SuperheroPlayers[player.Handle];
        if (shPlayer == null) { return; }

        List<SuperheroAbility> nonPlayerAbilities = SuperheroUtilities
            .filterExistingPlayerAbilities(shPlugin.AbilityManager.Abilities, shPlayer.playerAbilities);
        List<SuperheroAbility> availableAbilities = SuperheroUtilities
            .filterMinimumLevelAbilities(nonPlayerAbilities, shPlayer.currentLevel);

        ChatMenu addAbilityMenu = new ChatMenu("Add ability menu");
        foreach(SuperheroAbility shAbility in availableAbilities)
        {
            addAbilityMenu.AddMenuOption(StringResources.AbilityOption(shAbility.minLevel, shAbility.abilityName),
                (player, option) => { shPlayer.addAbility(shAbility); });
        }
        ChatMenus.OpenMenu(shPlayer.Player, addAbilityMenu);
    }
}
