using System.Collections.Generic;

public interface IImprovementRoomData
{
    Trainer Trainer { get; }
    CharacteristicType CurrcharacteristicType { get; }
    IReadOnlyList<CharacteristicType> CharacteristicTypes { get; }
    IReadOnlyList<Hero> HeroesTest { get; }
    Hero Hero { get; }
    FinderMode FinderMode { get; }
    bool IsUpdated { get; }
    bool IsAutoTraining { get; }
    bool IsHaveTrainingHero { get; }

    void SetTrainingHero(Hero hero);
}