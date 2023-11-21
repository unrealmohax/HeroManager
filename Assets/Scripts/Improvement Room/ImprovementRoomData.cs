using System;
using System.Collections.Generic;

public class ImprovementRoomData : IImprovementRoomData
{
    private Trainer _trainer;

    private readonly CharacteristicType[] _characteristicTypes;
    private CharacteristicType _currcharacteristicType;
    private List<Hero> _heroesTest;
    private Hero _trainingHero;

    private bool _isUpdated;
    private bool _isAutoTraining;

    public ImprovementRoomData(CharacteristicType[] characteristicTypes, IEnumerable<Hero> heroesTest)
    {
        _characteristicTypes = characteristicTypes;
        _currcharacteristicType = _characteristicTypes[0];
        _heroesTest = new List<Hero>(heroesTest); ;
    }

    #region IImprovementRoomData
    public Trainer Trainer => _trainer;
    public IReadOnlyList<CharacteristicType> CharacteristicTypes =>_characteristicTypes;
    public CharacteristicType CurrcharacteristicType => _currcharacteristicType;
    public IReadOnlyList<Hero> HeroesTest => _heroesTest;
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

    public void EnableAutoTraining() => _isAutoTraining = true;
    public void DisableAutoTraining() => _isAutoTraining = false;

}