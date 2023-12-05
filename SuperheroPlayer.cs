using CounterStrikeSharp.API.Core;
using SuperheroPlugin.Abilities;

namespace SuperheroPlugin;


public class SuperheroPlayer
{
    public CCSPlayerController GetPlayer() => Player;
    public CCSPlayerController Player { get; init; }

    public int currentXp;
    public int currentLevel;
    public int levelUpXp;
    public int availableAbilityPoints;
    public int maxLevel;
    public List<int> xpCurve;
    public List<SuperheroAbility> playerAbilities;

    public SuperheroPlayer(CCSPlayerController player, List<int> xpCurve, int maxLevel)
    {
        Player = player;
        this.currentXp = 0;
        this.currentLevel = 1;   
        this.availableAbilityPoints = 1;
        this.maxLevel = maxLevel;
        this.xpCurve = xpCurve;
        this.levelUpXp = xpCurve[0];
        this.playerAbilities = new List<SuperheroAbility>();
    }

    // Works by using the current level index
    // the xpCurve. Careful for -1 index.
    public void getNewLevelUpXp()
    {
        this.levelUpXp = xpCurve[ this.currentLevel - 1 ];
    }
        
    // Uses recursion, mby shouldn't do that
    public void checkLevel()
    {
        if (this.currentXp < this.levelUpXp || this.currentLevel >= this.maxLevel) { return; }
        // Print gained level and AP

        int turnOverXp = currentXp - levelUpXp;
        this.currentLevel += 1;
        this.availableAbilityPoints += 1;
        this.currentXp = turnOverXp;

        this.Player.PrintToChat(StringResources.GainedLevel(this.currentLevel, this.availableAbilityPoints));
        this.getNewLevelUpXp();
        this.checkLevel();
        return;
    }

    public void addXp(int x)
    {
        this.currentXp += x;
        this.Player.PrintToChat(StringResources.GainedXp(x));
        this.checkLevel();
    }

    public void addAbility(SuperheroAbility shAbility)
    {
        if (shAbility == null) { return; }
        if (this.availableAbilityPoints < 1){ 
            this.Player.PrintToChat(StringResources.NotEnoughAp()); 
            return; 
        }
        this.availableAbilityPoints -= 1;
        this.playerAbilities.Add(shAbility);
        this.Player.PrintToChat(StringResources.AddedAbility(shAbility.abilityName));
        shAbility.activate(this);
    }

    public void activateRoundStartAbilities()
    {
        foreach (SuperheroAbility ability in this.playerAbilities)
        {
            Console.WriteLine($"Activating {ability.abilityName}");
            if (ability.onRoundStartActivate) { ability.activate(this); }
        }
    }

}

