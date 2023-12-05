
namespace SuperheroPlugin;

public static class SuperheroSetup
{
	
	public static void SetupCommands(SuperheroPlugin shPlugin)
	{
        shPlugin.AddCommand("ap", "Ability add menu",
			(player, info) => { SuperheroMenus.generateAddAbilityMenu(player, shPlugin); });
		shPlugin.AddCommand("lvl", "Show user level",
			(player, info) => {
				if (player?.Handle == null) { return; }
				SuperheroPlayer shPlayer = shPlugin.SuperheroPlayers[player.Handle];
				if (shPlayer == null) { return; }
                SuperheroTasks.printLevel(shPlayer, 0); 
			});
	}

}
