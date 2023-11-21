public interface IStateSwitcher
{
    IState CurrentState { get; }
    void SwitchState<State>() where State : IState;
}