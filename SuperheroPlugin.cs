using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;

namespace SuperheroPlugin;

public partial class SuperheroPlugin : BasePlugin
{
    public override string ModuleName => "Superhero plugin";
    public override string ModuleVersion => "0.0.13";

    public int XpPerKill = 10;
    public float XpHeadshotMultiplier = 1.5f;
    public float XpKnifeMultiplier = 3f;
    public float XpAssistMultiplier = 0.3f;
    public int maxLevel = 10;
    public List<int> xpCurve = new();

    public Dictionary<IntPtr, SuperheroPlayer> SuperheroPlayers = new();
    public List<SuperheroPlayer> Players => SuperheroPlayers.Values.ToList();
    public AbilityManager AbilityManager = new AbilityManager();


    public override void Load(bool hotReload)
    {
        Console.WriteLine(string.Format("Loaded : {0}, Version: {1}", this.ModuleName, this.ModuleVersion));

        // Register listeners
        RegisterListener<Listeners.OnClientConnected>(OnClientPutInServerHandler);
        RegisterListener<Listeners.OnClientDisconnect>(OnClientDisconnectHandler);

        //Setup methods
        SuperheroSetup.SetupCommands(this);
        this.xpCurve = SuperheroUtilities.generateXpLevelCurve(this.maxLevel);

    }

    private void OnClientPutInServerHandler(int slot)
    {
        var player = Utilities.GetPlayerFromSlot(slot);
        if (!player.IsValid || player.IsBot) return;
        SuperheroPlayers[player.Handle] = new SuperheroPlayer(player, this.xpCurve, this.maxLevel);
    }

    private void OnClientDisconnectHandler(int slot)
    {
        var player = Utilities.GetPlayerFromSlot(slot);
        if (!player.IsValid || player.IsBot) return;

        RemoveShPlayer(player);
    }


    public void RemoveShPlayer(CCSPlayerController player)
    {    
        SuperheroPlayers.Remove(player.Handle);
    }

}
