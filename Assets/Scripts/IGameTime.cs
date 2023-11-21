public interface IGameTime : IUpdatable
{
    GameTime GameTime { get; }

    void SetAccelerationRatio(int value);
}