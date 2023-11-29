using System;
using System.Collections.Generic;

public class ImprovementRoomData : IImprovementRoomData
{
    private Trainer _trainer;

    private readonly CharacteristicType[] _characteristicTypes;
    private CharacteristicType _currcharacteristicType;
    private IReadOnlyDictionary<string, Hero> _heroesTest;
    private Hero _trainingHero;

    private FinderMode _currentfinderMode;

    private bool _isUpdated;
    private bool _isAutoTraining;

    public ImprovementRoomData(CharacteristicType[] characteristicTypes, IReadOnlyDictionary<string, Hero> heroesTest)
    {
        _characteristicTypes = characteristicTypes;
        _currcharacteristicType = _characteristicTypes[0];
        _heroesTest = heroesTest;
    }

    #region IImprovementRoomData
    public Trainer Trainer => _trainer;
    public IReadOnlyList<CharacteristicType> CharacteristicTypes =>_characteristicTypes;
    public CharacteristicType CurrcharacteristicType => _currcharacteristicType;
    public IReadOnlyList<Hero> HeroesTest => new List<Hero>(_heroesTest.Values);
    public Hero Hero => _trainingHero;
    public FinderMode FinderMode => _currentfinderMode;
    public bool IsUpdated => _isUpdated;
    public bool IsAutoTraining => _isAutoTraining;
    public bool IsHaveTrainingHero => _trainingHero != null;
    #endregion

    public void SetTrainer(Trainer trainer) 
    {
        if (trainer == null) throw new Exception("SetTrainerException trainer - null");

        _trainer = trainer;
    }

    public void SetTrainingHero(Hero hero)
    {
        if (hero == null) throw new Exception("SetTrainingHeroException hero - null");

        _trainingHero = hero;
    }
    public void SetFinderMode(FinderMode mode) => _currentfinderMode = mode;
    public void EnableAutoTraining() => _isAutoTraining = true;
    public void DisableAutoTraining() => _isAutoTraining = false;

}