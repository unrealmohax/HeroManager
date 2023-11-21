public sealed class HeroSearchState : ImprovementRoomActionsState
{
    private readonly FinderCreator _finderCreator;

    public HeroSearchState (IStateSwitcher switcher, IImprovementRoomData improvementRoomData) : base(switcher, improvementRoomData)
    {
        _finderCreator = new FinderCreator();
    }

    public override void Handle()
    {
        base.Handle();

        if (_finderCreator.GetFinderStratigy(_data.FinderMode, out var stratigy))
        {
            if (stratigy.TryFindHero(_data.HeroesTest, _data.CurrcharacteristicType, out Hero hero))
            {
                _data.SetTrainingHero(hero);
            }
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

