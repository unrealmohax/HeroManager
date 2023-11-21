public class ImprovingTrainerAbilitiesState : ImprovementRoomActionsState
{
    public ImprovingTrainerAbilitiesState(IStateSwitcher switcher, IImprovementRoomData improvementRoomData) : base(switcher, improvementRoomData)
    {
    }

    public override void Update()
    {
        base.Update();

        if (IsUpdatable) 
        {
            _switcher.SwitchState<RoomUpdateState>();
        };

        if (IsHaveTrainingHero) 
        {
            _switcher.SwitchState<ImprovingHeroCharacteristicsState>();
        }

        if (IsTraining)
        {
            if (IsAutoTraining)
            {
                _switcher.SwitchState<HeroSearchState>();
            }
        }
        else
        {
            _switcher.SwitchState<InactionState>();
        }
    }
}

