using System;
using System.Linq;

public class UpgradableCharacteristic 
{
    private readonly string _name;
    private readonly string _description;
    private int _value;
    private readonly int _maxValue;
    private float _progress;
    private readonly CharacteristicType _characteristicType;

    private const float MAX_PROGRESS = 100f;
    private const int MAX_ALLOWED_VALUE = 99;

    public UpgradableCharacteristic(int Value, int MaxValue, CharacteristicType characteristicType)
    {
        Characteristic characteristic = CharacteristicsDB.Characteristics.FirstOrDefault(c => c.Type == characteristicType);
        _name = characteristic.Name ?? throw new Exception("There was an attempt to create a parameter with incorrect parameters (Name - null)");
        _description = characteristic.Description ?? throw new Exception("There was an attempt to create a parameter with incorrect parameters (Description - null)");

        if (Value < 0 || MaxValue < 0 || Value > MaxValue) throw new Exception("There was an attempt to create a parameter with incorrect parameters");

        if (MaxValue > MAX_ALLOWED_VALUE) MaxValue = MAX_ALLOWED_VALUE;

        _value = Value;
        _maxValue = MaxValue;
        _progress = 0;
        _characteristicType = characteristicType;
    }

    public string Name => _name;
    public string Description => _description;
    public int Value => _value;
    public int MaxValue => _maxValue;
    public float Progress => _progress;
    public CharacteristicType CharacteristicType => _characteristicType;

    public bool AddProgress(float progress) 
    {
        if (progress < 0) return false;

        while (progress > 0) 
        {
            if (GetProgressToMaxProgress() > progress)
            {
                _progress += progress;
                progress = 0;
            }
            else 
            {
                progress -= GetProgressToMaxProgress();

                _progress = 0;
                _value++;
            }
        }

        return true;
    }

    protected float GetProgressToMaxProgress() 
    {
        return MAX_PROGRESS - _progress;
    }
}
