public class GameTimer : IGameTime
{
    private int _day;
    private int _hour;
    private float _minute;

    private const float TIME_RATIO = 5;
    private const int MINUTES_IN_HOUR = 60;
    private const int HOURS_IN_DAY = 24;

    private int accelerationRatio = 1;

    public void Update(float deltaTime)
    {
        _minute += (deltaTime / TIME_RATIO) * accelerationRatio;
        if (_minute >= MINUTES_IN_HOUR) 
        {
            _minute = 0;
            _hour++;

            if (_hour == HOURS_IN_DAY) 
            {
                _hour = 0;
                _day++;
            }
        }
    }
    public GameTime GameTime => new (_day, _hour, (int)_minute);

    public void SetAccelerationRatio(int value) 
    {
        if (value < 1) throw new System.Exception($"Incorrect accelerationRatio - {value}");

        accelerationRatio = value;
    }
}
public readonly struct GameTime
{
    public readonly int Days;
    public readonly int Hours;
    public readonly int Minutes;

    public GameTime(int days, int hours, int minutes)
    {
        Days = days;
        Hours = hours;
        Minutes = minutes;
    }
}