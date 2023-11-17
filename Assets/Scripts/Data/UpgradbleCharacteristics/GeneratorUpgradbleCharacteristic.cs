using System;

internal class GeneratorUpgradbleCharacteristic
{
    private readonly IGeneratorConfig _config;

    private int _minValueChance;
    private int _minvalue = 1;
    private int _maxValue = 1;

    private const int MIN_VALUE_CHANCE = 1;
    private const int MAX_VALUE_CHANCE = 100;

    public GeneratorUpgradbleCharacteristic(IGeneratorConfig config)
    {
       _config = config ?? throw new Exception("There was an attempt to create a Generator with incorrect parameters (Config - null)"); ;
    }

    public CharacteristicValue Generate(int minValueChance) 
    {
        if (minValueChance < 1) throw new Exception("There was an attempt to create a parameter with incorrect parameters (ValueChance < 1)");

        _minValueChance = minValueChance;

        var random = new Random();
        int chance = random.Next(_minValueChance, MAX_VALUE_CHANCE);

        float cumulativeWeight = 0;
        foreach (var w in _config.WeightValues) 
        {
            cumulativeWeight += w.ChanceValue;
            if (cumulativeWeight < chance) continue;
            
            _minvalue = w.Value + random.Next(0, 9);
            break;
        }

        int maxChance = random.Next(MIN_VALUE_CHANCE, MAX_VALUE_CHANCE);
        maxChance = (maxChance + chance) / 2;
        _maxValue = _minvalue + maxChance * (_config.MaxValue - _minvalue) / 100;
        return new CharacteristicValue(_minvalue, _maxValue);
    }
}

public readonly struct CharacteristicValue 
{
    public readonly int MinValue;
    public readonly int MaxValue;

    public CharacteristicValue(int minvalue, int maxValue)
    {
        MinValue = minvalue;
        MaxValue = maxValue;
    }
}

