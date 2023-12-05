using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Memory;

namespace SuperheroPlugin.Abilities;

public class DeagloManiacAbility : SuperheroAbility
{
    public override string abilityName => "DeagloManiac";
    public override bool isUsable => false;
    public override bool onRoundStartActivate => true;
    public override int minLevel => 1;

    public override void activate(SuperheroPlayer shPlayer)
    {
        if (shPlayer?.Player?.PlayerPawn?.Value == null) { return; }
        CCSPlayerPawn pawn = shPlayer.Player.PlayerPawn.Value;
        if (pawn.WeaponServices == null || pawn.ItemServices == null) { return; }
        string wepDeagle = "weapon_deagle";
   
        foreach (var wep in pawn.WeaponServices.MyWeapons)
        {
            if (wep?.IsValid == true && wep.Value?.IsValid == true
                && !string.IsNullOrWhiteSpace(wep.Value.DesignerName)
                && SuperheroUtilities.secondaryWeaponsList.Contains(wep.Value.DesignerName)) 
            {
                wep.Value.Remove();
            }
        }

        VirtualFunctions.GiveNamedItem(pawn.ItemServices.Handle, wepDeagle, 0, 0, 0, 0);
    }
}
