public class InactionState : ImprovementRoomActionsState
{
    public InactionState(IStateSwitcher switcher, IImprovementRoomData improvementRoomData) : base(switcher, improvementRoomData)
    {
    }

    public override void Update()
    {
        base.Update();

        if (IsUpdatable)
        {
            _switcher.SwitchState<RoomUpdateState>();
        }

        if (IsTraining)
        {
            if (IsAutoTraining)
            {
                if (IsHaveTrainingHero)
                {
                    _switcher.SwitchState<ImprovingHeroCharacteristicsState>();
                }
                else 
                {
                    _switcher.SwitchState<HeroSearchState>();
                }
            }   
            else
                _switcher.SwitchState<ImprovingTrainerAbilitiesState>();
        }
    }
}
