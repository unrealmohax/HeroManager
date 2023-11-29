public class ImprovingHeroCharacteristicsState : ImprovementRoomActionsState
{
    public ImprovingHeroCharacteristicsState(IStateSwitcher switcher, IImprovementRoomData improvementRoomData) : base(switcher, improvementRoomData)
    {
    }

    public override void Handle()
    {
        base.Handle();

        int heroValue = GetCharacteristicValue(_data.Hero.Info);
        int trainerValue = GetCharacteristicValue(_data.Trainer.Info);

        float progress = Get(heroValue, trainerValue);

        _data.Hero.AddProgressCharacteristic(_data.CurrcharacteristicType, progress);
    }

    public override void Update()
    {
        base.Update();

        if (IsUpdatable) 
        {
            _switcher.SwitchState<RoomUpdateState>();
        }

        if (IsHaveTrainingHero) return;

        if (IsAutoTraining) 
        {
            _switcher.SwitchState<HeroSearchState>();
        }

        if (IsTraining)
        {
            _switcher.SwitchState<ImprovingTrainerAbilitiesState>();
        }
        else 
        {
            _switcher.SwitchState<InactionState>();
        }
    }

    private int GetCharacteristicValue(IInfo info)
    {
        return info.CharacteristicsMap[_data.CurrcharacteristicType].Value; 
    }

    private float Get(int valueHero, int valueTrainer) 
    {
        return valueHero <= valueTrainer ? _data.Trainer.LearningRate * 10 : _data.Trainer.LearningRate / 10;
    }
}
