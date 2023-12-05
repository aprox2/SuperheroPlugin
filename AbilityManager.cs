using System.Reflection;
using SuperheroPlugin.Abilities;

namespace SuperheroPlugin;

public class AbilityManager
{
    public List<SuperheroAbility> Abilities = new List<SuperheroAbility>();

    public AbilityManager()
    {
        LoadAbilities();
    }

    private void LoadAbilities()
    {
        // Get the assembly where the abilities are defined
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Get all types in the assembly that are assignable to SuperheroAbility
        IEnumerable<Type> abilityTypes = assembly.GetTypes()
            .Where(type => type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(SuperheroAbility)));

        foreach (Type type in abilityTypes)
        {
            // Create an instance of the ability and add it to the list
            SuperheroAbility? ability = (SuperheroAbility?)Activator.CreateInstance(type);
            if (ability == null) { continue; }
            Abilities.Add(ability);
        }

    }

}

