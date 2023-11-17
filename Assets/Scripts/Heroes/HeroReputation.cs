public class HeroReputation : Reputation
{
    protected override int GetNeedLevelReputationPoints()
    {
        return LEVEL_REPUTATION_POINTS * Factorial(_level);
    }

    protected override int Factorial(int level)
    {
        if (level == 0) return 1;
        return level + Factorial(level - 1);
    }
}
