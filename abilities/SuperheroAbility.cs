
namespace SuperheroPlugin.Abilities;

public abstract class SuperheroAbility
{
    public SuperheroAbility() { }

    public abstract string abilityName { get; }
    public abstract bool isUsable { get; }

    // If this is true, then activate() will be called on round_start event
    public abstract bool onRoundStartActivate { get; }
    public abstract int minLevel { get; }

    // Base method to activate the ability.
    public virtual void activate(SuperheroPlayer shPlayer) { }
    // Base method to use the ability. This is still planned in the future, when CSS
    // will allow to add custom commands.
    public virtual void use() { }

}
