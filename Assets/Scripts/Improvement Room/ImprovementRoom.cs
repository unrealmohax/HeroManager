using System.Collections.Generic;
using System.Linq;

public  class ImprovementRoom 
{
    private readonly string _name;
    private readonly string _description;
    private readonly ImprovementRoomStateMachine _statemachine;
    private readonly ImprovementRoomData _data;

    public ImprovementRoom(string name, string description, CharacteristicType[] characteristicTypes, IReadOnlyDictionary<string, Hero> heroesTest)
    {
        _name = name;
        _description = description;
        _data = new ImprovementRoomData((CharacteristicType[])characteristicTypes.Clone(), heroesTest);
        _statemachine = new ImprovementRoomStateMachine(_data);
    }

    public string Name => _name;
    public string Description => _description;
    public ImprovementRoomStateMachine StateMachine => _statemachine;
    public ImprovementRoomData Data => _data;

    public bool TrySetTrainer(Trainer trainer) 
    {
        if (trainer == null) return false;

        var trainerCharacteristicsType = trainer.Info.GetCharacteristicTypes();

        foreach (var type in _data.CharacteristicTypes)
        {
            if (trainerCharacteristicsType.Contains(type))
            {
                _data.SetTrainer(trainer);
                return true;
            }
        }

        return false;
    }

    public bool TrySetHero(Hero hero)
    {
        if (hero == null) return false;

        _data.SetTrainingHero(hero);
        return true;
    }
}
