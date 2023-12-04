using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Attributes.Registration;

namespace SuperheroPlugin;

public partial class SuperheroPlugin
{
	[GameEventHandler(HookMode.Post)]
	public HookResult OnRoundStart(EventRoundStart @event, GameEventInfo info)
	{
		SuperheroTasks.printLevelToAllPlayers(this.SuperheroPlayers);
		SuperheroTasks.activatePlayerOnRoundStartAbilities(this.SuperheroPlayers);
		return HookResult.Continue;
	}

	[GameEventHandler(HookMode.Post)]
	public HookResult OnPlayerDeath(EventPlayerDeath @event, GameEventInfo info) 
	{

		if (@event.Userid == null 
			|| @event.Attacker == null 
			|| @event.Attacker.Handle == @event.Userid.Handle
			|| @event.Attacker.IsBot == true
		) { return HookResult.Continue; }

        SuperheroPlayer attackerPlayer = SuperheroPlayers[@event.Attacker.Handle];
        bool isHeadshot = @event.Headshot;
		int xpToAddAttacker = this.XpPerKill;
		xpToAddAttacker = (int) (isHeadshot ? xpToAddAttacker * this.XpHeadshotMultiplier : xpToAddAttacker);
		attackerPlayer.addXp(xpToAddAttacker);

		// TEMP FIX
		if (@event.Assister == null	|| @event.Assister.IsBot == true) { return HookResult.Continue; }

		SuperheroPlayer assisterPlayer = SuperheroPlayers[@event.Assister.Handle];
		if ( assisterPlayer == null ) { return HookResult.Continue; }
		int xpToAddAssister = (int) (this.XpPerKill * this.XpAssistMultiplier);
		assisterPlayer.addXp(xpToAddAssister);

		return HookResult.Continue;
    }
}
