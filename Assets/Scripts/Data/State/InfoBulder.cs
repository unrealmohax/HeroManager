public class InfoBulder<T> : IInfoBulder where T : IInfo, new()
{
    private T _info;

    public InfoBulder()
    {
        _info = new T();
    }

    public IInfoBulder AddCharacteristic(CharacteristicType type, CharacteristicValue characteristic)
    {
        UpgradableCharacteristic upgradableCharacteristic = new(characteristic.MinValue, characteristic.MaxValue, type);
        _info.AddCharacteristic(type, upgradableCharacteristic);
        return this;
    }

    public IInfo GetInfo()
    {
        IInfo state = _info;
        _info = new T();
        return state;
    }
}
