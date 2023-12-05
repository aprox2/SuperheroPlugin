
namespace SuperheroPlugin.Abilities;

public class AddHpAbility : SuperheroAbility
{
    public override string abilityName => "+50hp";
    public override bool isUsable => false;
    public override bool onRoundStartActivate => true;
    public override int minLevel => 1;

    public override void activate(SuperheroPlayer shPlayer)
    {
        if (shPlayer == null || shPlayer.Player == null) { return; }
        shPlayer.Player.PlayerPawn!.Value.MaxHealth += 50;
        shPlayer.Player.PlayerPawn!.Value.Health += 50;
        SuperheroUtilities.RefreshUI(shPlayer);
    }

}
