using UnityEngine;

public class ImprovingHeroCharacteristicsState : ImprovementRoomActionsState
{
    public ImprovingHeroCharacteristicsState(IStateSwitcher switcher, IImprovementRoomData improvementRoomData) : base(switcher, improvementRoomData)
    {
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
}
