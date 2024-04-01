
using CounterStrikeSharp.API.Core;

namespace SuperheroPlugin.Abilities;

public class SpeedsterAbility : SuperheroAbility
{
    public override string abilityName => "Speedster";

    public override bool isUsable => false;

    public override bool onRoundStartActivate => false;

    public override int minLevel => 1;

    public override void activate(SuperheroPlayer shPlayer)
    {
        if (shPlayer?.Player?.PlayerPawn?.Value == null) { return; }
        CCSPlayerPawn pawn = shPlayer.Player.PlayerPawn.Value;

        pawn.VelocityModifier += 2;
        pawn.GravityScale += 2;

    }
}
