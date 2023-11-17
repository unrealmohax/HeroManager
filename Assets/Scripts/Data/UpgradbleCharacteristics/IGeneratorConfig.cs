using System.Collections.Generic;

public interface IGeneratorConfig
{
    IReadOnlyList<ConfigData> WeightValues { get; }
    int MaxValue { get; }
}