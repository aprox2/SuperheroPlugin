using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace SuperheroPlugin.Abilities;

public abstract class SuperheroAbility
{
    public SuperheroAbility() { }

    public abstract string abilityName { get; }
    public abstract bool isUsable { get; }
    public abstract bool onRoundStartActivate { get; }
    public abstract int minLevel { get; }

    public virtual void activate(SuperheroPlayer shPlayer) { }
    public virtual void use() { }

}
