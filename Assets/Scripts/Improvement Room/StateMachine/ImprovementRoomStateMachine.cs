using System.Collections.Generic;
using System.Linq;

public class ImprovementRoomStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public ImprovementRoomStateMachine(IImprovementRoomData improvementRoomData)
    {
        _states = new List<IState>()
        {
            new InactionState(this, improvementRoomData),
            new ImprovingTrainerAbilitiesState(this, improvementRoomData), 
            new ImprovingHeroCharacteristicsState(this, improvementRoomData),
            new RoomUpdateState(this, improvementRoomData),
            new HeroSearchState(this, improvementRoomData),
        };

        _currentState = _states[0];
        _currentState.Enter();
    }

    public IState CurrentState => _currentState;

    public void SwitchState<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void Update() => _currentState.Update();
    public void Handle() => _currentState.Handle();
}
