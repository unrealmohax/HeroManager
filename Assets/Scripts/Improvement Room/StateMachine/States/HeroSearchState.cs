public class HeroSearchState : ImprovementRoomActionsState
{
    private IFinderHeroTraining _finder;

    public HeroSearchState (IStateSwitcher switcher, IImprovementRoomData improvementRoomData) : base(switcher, improvementRoomData)
    {
        _finder = new MaxCharacteristicStratagy();
    }

    public override void Handle()
    {
        base.Handle();

        if (_finder.TryFindHero(_data.HeroesTest, _data.CurrcharacteristicType, out Hero hero))
        {
            _data.SetTrainingHero(hero);
        } 
    }

    public override void Update()
    {
        base.Update();

        if (IsUpdatable) return;

        if (IsAutoTraining)
        {
            if (IsHaveTrainingHero)
            {
                _switcher.SwitchState<ImprovingHeroCharacteristicsState>();
            }
        }
        else

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

