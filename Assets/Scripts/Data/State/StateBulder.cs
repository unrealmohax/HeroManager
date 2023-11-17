using System;

public class StateBulder : IInfoBulder
{
    private IInfo _heroState;

    public StateBulder()
    {
        _heroState = new HeroInfo();
    }

    public IInfoBulder AddCharacteristic(CharacteristicType type, CharacteristicValue characteristic)
    {
        CheckValidparametrs(characteristic);

        UpgradableCharacteristic upgradableCharacteristic = new(characteristic.MinValue, characteristic.MaxValue, type);
        _heroState.AddCharacteristic(type, upgradableCharacteristic);
        return this;
    }

    public IInfo GetState()
    {
        IInfo state = _heroState;
        _heroState = new Info();
        return state;
    }

    private void CheckValidparametrs(CharacteristicValue value)
    {
        if (value.MinValue <= 0 || value.MaxValue <= 0) throw new Exception("There was an attempt to create a trainer State with incorrect parameters (value <= 0)");
    }
}
