using System;

public class RoomData : IRoomData
{
    private int _level;
    private int _currPoint;

    private readonly int _maxLevel;

    protected const int LEVEL_REPUTATION_POINTS = 100;

    public RoomData(int maxlevel)
    {
        if (maxlevel <= 0) throw new Exception("There was an attempt to create a room with incorrect parameters (RoomState maxlevel <= 0)");

        _maxLevel = maxlevel;
    }
    public int Level => _level;
    public int MaxLevel => _maxLevel;
    public int CurrentPoint => _currPoint;

    public bool AddUpgradeRoomPoint(int upgradeRoomPoint)
    {
        if (upgradeRoomPoint < 0) return false;

        if (_level == _maxLevel)
        {
            _currPoint += upgradeRoomPoint;
            return true;
        }

        while (upgradeRoomPoint > 0)
        {
            if (GetNeedLevelPoints() > upgradeRoomPoint + _currPoint)
            {
                _currPoint += upgradeRoomPoint;
                upgradeRoomPoint = 0;
            }
            else
            {
                upgradeRoomPoint -= GetNeedLevelPoints();

                _currPoint = 0;
                _level++;
            }
        }

        return true;
    }

    private int GetNeedLevelPoints()
    {
        return LEVEL_REPUTATION_POINTS * Factorial(_level);
    }

    private int Factorial(int level)
    {
        if (level == 0) return 1;
        return level * Factorial(level - 1);
    }


}
