using System.Collections.Generic;

internal class Barracks : ImprovementRoom
{
    internal Barracks(BarrackBuildConfig config, IReadOnlyDictionary<string, Hero> heroes) : base (config.Name, config.Description, config.CharacteristicType, heroes)
    {
    }
}
