using System.Collections.Generic;

public class Info : IInfo
{
    private readonly Dictionary<CharacteristicType, UpgradableCharacteristic> _listcharacteristics;

    public Info()
    {
        _listcharacteristics = new Dictionary<CharacteristicType, UpgradableCharacteristic>();
    }

    public IReadOnlyDictionary<CharacteristicType, UpgradableCharacteristic> CharacteristicsMap => _listcharacteristics;

    public bool AddCharacteristic(CharacteristicType type, UpgradableCharacteristic upgradableCharacteristic) 
    {
        if (upgradableCharacteristic == null) return false;

        if (_listcharacteristics.ContainsKey(type)) return false;

        _listcharacteristics.Add(type, upgradableCharacteristic);
        return true;
    }

    public IReadOnlyList<CharacteristicType> GetCharacteristicTypes()
    {
        return new List<CharacteristicType>(_listcharacteristics.Keys);
    }
}
