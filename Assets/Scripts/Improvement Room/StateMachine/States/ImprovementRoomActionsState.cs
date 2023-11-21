using UnityEngine;

public abstract class ImprovementRoomActionsState : IState
{
    protected readonly IStateSwitcher _switcher;
    protected readonly IImprovementRoomData _data;

    public ImprovementRoomActionsState(IStateSwitcher switcher, IImprovementRoomData data)
    {
        _switcher = switcher;
        _data = data;
    }

    public bool IsUpdatable => _data.IsUpdated;
    public bool IsAutoTraining => _data.IsAutoTraining;
    public bool IsHaveTrainingHero => _data.IsHaveTrainingHero;
    public bool IsTraining => _data.Trainer != null;

    public virtual void Enter()
    {
        Debug.Log(GetType() + " Enter");
    }

    public virtual void Exit()
    {
        Debug.Log(GetType() + " Exit");
    }

    public virtual void Update()
    {
        Debug.Log(GetType() + " Update");
    }

    public virtual void Handle()
    {
        Debug.Log(GetType() + " Handle");
    }
}

