public class RoomUpdateState : ImprovementRoomActionsState
{
    public RoomUpdateState(IStateSwitcher switcher, IImprovementRoomData improvementRoomData) : base(switcher, improvementRoomData)
    {
    }

    public override void Update()
    {
        base.Update();

        if (IsUpdatable) return;

        _switcher.SwitchState<InactionState>();
    }
}

