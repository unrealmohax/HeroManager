using System.Collections.Generic;

public class MinCharacteristicsStratagy : FinderHeroTraining
{
    public override bool TryFindHero(IEnumerable<Hero> fullheroList, CharacteristicType type, out Hero heroTraining)
    {
        heroTraining = null;
        List<Hero> heroList = new (fullheroList);

        foreach (var hero in heroList)
        {
            if (hero.CurrState == HeroState.Free) 
            {
                if (heroTraining == null)
                {
                    heroTraining = hero;
                }
                else
                {
                    var heroCharacteristic  = hero.Info.CharacteristicsMap.GetValueOrDefault(type);
                    var heroTrainingCharacteristic = heroTraining.Info.CharacteristicsMap.GetValueOrDefault(type);

                    if (heroCharacteristic.Value < heroTrainingCharacteristic.Value) 
                    {
                        heroTraining = hero;
                    }
                }
            }
        }

        return heroTraining != null;
    }
}
