using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public  class ImprovementRoom 
{
    private readonly string _name;
    private readonly string _description;
    private readonly IRoomState _state;
    private Trainer _trainer;
    private IFinderHeroTraining _finder;

    private readonly CharacteristicType[] _characteristicTypes;
    private CharacteristicType _currcharacteristicType;

    private List<Hero> _heroesTest;
    public ImprovementRoom(string name, string description, CharacteristicType[] characteristicTypes, IEnumerable<Hero> heroesTest)
    {
        _name = name;
        _description = description;

        _characteristicTypes = (CharacteristicType[])characteristicTypes.Clone();
        _currcharacteristicType = _characteristicTypes[0];
        _heroesTest = new List<Hero>(heroesTest);
        //_state = new RoomState();
    }

    public string Name => _name;
    public string Description => _description;
    public IRoomState State => _state;
    public CharacteristicType[] CharacteristicTypes => _characteristicTypes;

    public bool TrySetTrainer(Trainer trainer) 
    {
        if (trainer == null) return false;

        var trainerCharacteristicsType = trainer.State.GetCharacteristicTypes();

        foreach (var type in _characteristicTypes)
        {
            if (trainerCharacteristicsType.Contains(type))
            {
                _trainer = trainer;

                CoroutineController.StartCoroutine(StartTraining(), "StartTraining");
                return true;
            }
        }

        return false;
    }
    public void TrySetFinder() 
    {
        _finder = new MaxCharacteristicStratagy();
    }

    private IEnumerator StartTraining()
    {
        if (_finder == null) throw new System.Exception("Finder - null");

        if (_finder.TryFindHero(_heroesTest, _currcharacteristicType, out Hero hero))
        {
            Debug.Log($"{hero.FirstName} {hero.SecondName}");
        }

        yield return null;
    }
}
