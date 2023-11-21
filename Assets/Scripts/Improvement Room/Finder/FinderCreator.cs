using System.Collections.Generic;

public class FinderCreator
{
    private Dictionary<FinderMode, IFinderHeroTraining> _finder = new Dictionary<FinderMode, IFinderHeroTraining>() 
    {
        { FinderMode.MinValue, new MinCharacteristicsStratagy() },
        { FinderMode.MaxValue, new MaxCharacteristicStratagy() },
    };


    public bool GetFinderStratigy(FinderMode mode, out IFinderHeroTraining finderHeroTraining) 
    {
        return _finder.TryGetValue(mode, out finderHeroTraining);
    }
}
public enum FinderMode 
{
    MinValue,
    MaxValue,
}

