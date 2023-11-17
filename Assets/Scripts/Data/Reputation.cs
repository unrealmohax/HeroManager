public abstract class Reputation
{
    protected int _level;
    protected int _currReputationPoints;

    public const int MAX_LEVEL = 10;
    protected const int LEVEL_REPUTATION_POINTS = 100;

    public int Level => _level;
    public int MaxLevel => MAX_LEVEL;
    public float Progress => ((float)_currReputationPoints / GetNeedLevelReputationPoints()) * 100f;


    public bool AddReputationPoint(int reputationPoint)
    {
        if (reputationPoint < 0) return false;

        if (_level == MAX_LEVEL) 
        {
            _currReputationPoints += reputationPoint;
            return true;
        }

        while (reputationPoint > 0)
        {
            if (GetNeedLevelReputationPoints() > reputationPoint + _currReputationPoints)
            {
                _currReputationPoints += reputationPoint;
                reputationPoint = 0;
            }
            else
            {
                reputationPoint -= GetNeedLevelReputationPoints();

                _currReputationPoints = 0;
                _level++;
            }
        }

        return true;
    }

    protected virtual int GetNeedLevelReputationPoints() 
    {
        return LEVEL_REPUTATION_POINTS * Factorial(_level);
    }

    protected virtual int Factorial(int level)
    {
        if (level == 0) return 1;
        return level * Factorial(level - 1);
    }
}
