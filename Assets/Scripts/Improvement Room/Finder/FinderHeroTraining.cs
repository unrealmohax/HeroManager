using System.Collections.Generic;

public abstract class FinderHeroTraining : IFinderHeroTraining
{
    public abstract bool TryFindHero(IEnumerable<Hero> heroList, CharacteristicType type, out Hero hero);
}
