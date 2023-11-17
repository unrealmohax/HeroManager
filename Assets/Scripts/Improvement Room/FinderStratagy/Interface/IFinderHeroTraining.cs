using System.Collections.Generic;

public interface IFinderHeroTraining
{
    bool TryFindHero(IEnumerable<Hero> heroList, CharacteristicType type, out Hero hero);
}
