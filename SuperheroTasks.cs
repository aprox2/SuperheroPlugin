
namespace SuperheroPlugin;

public static class SuperheroTasks
{

    public static void printLevelToAllPlayers(Dictionary<IntPtr, SuperheroPlayer> shPlayers)
    { 
        foreach (var player in shPlayers) 
        {
            if (player.Value == null) { continue; }
            SuperheroTasks.printLevel(player.Value);
        }
    }

    public static void activatePlayerOnRoundStartAbilities(Dictionary<IntPtr, SuperheroPlayer> shPlayers)
    {
        Task.Run(() =>
        {
            foreach (var shPlayer in shPlayers)
            {
                if (shPlayer.Value == null || shPlayer.Value.Player == null) { continue; }
                shPlayer.Value.activateRoundStartAbilities();
            }
        });
    }

    public static void printLevel(SuperheroPlayer shPlayer, int firstDelay=2000)
    {
        if (shPlayer == null || shPlayer.Player == null) { return; }

        Task.Run(async () =>
        {
            await Task.Delay(firstDelay);

            var timer = new System.Timers.Timer();
            timer.Start();
            timer.Interval = 500;
            timer.Elapsed += (sender, e) =>
            {
                shPlayer.Player.PrintToCenter(
                    StringResources.LevelStatsMessage(
                        shPlayer.currentLevel, shPlayer.currentXp,
                        shPlayer.levelUpXp, shPlayer.availableAbilityPoints)
                );
            };
            await Task.Delay(12000);
            timer.Stop();
            timer.Dispose();
        });
    }

}
