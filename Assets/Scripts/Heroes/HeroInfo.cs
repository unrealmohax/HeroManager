using System;
using System.Collections.Generic;

public class HeroInfo : IHeroInfo
{
    private readonly HeroReputation _reputation;

    private readonly Dictionary<CharacteristicType, UpgradableCharacteristic> _listcharacteristics;

    public HeroInfo()
    {
        _listcharacteristics = new Dictionary<CharacteristicType, UpgradableCharacteristic>();
        _reputation = new();
    }
    
    public void AddCharacteristic(CharacteristicType type, UpgradableCharacteristic UpgradableCharacteristic)
    {
        if (UpgradableCharacteristic == null) return;

        if (_listcharacteristics.ContainsKey(type)) return;

        _listcharacteristics.Add(type, UpgradableCharacteristic);
    }

    public IReadOnlyDictionary<CharacteristicType, UpgradableCharacteristic> CharacteristicsMap => _listcharacteristics;
    public UpgradableCharacteristic Strenght => _listcharacteristics[CharacteristicType.Strenght];
    public UpgradableCharacteristic Agility => _listcharacteristics[CharacteristicType.Agility];
    public UpgradableCharacteristic Intellect => _listcharacteristics[CharacteristicType.Intellect];
    public UpgradableCharacteristic Stamina => _listcharacteristics[CharacteristicType.Stamina];
    public UpgradableCharacteristic Magic => _listcharacteristics[CharacteristicType.Magic];
    public UpgradableCharacteristic Charisma => _listcharacteristics[CharacteristicType.Charisma];
    public UpgradableCharacteristic Luck => _listcharacteristics[CharacteristicType.Luck];
    public UpgradableCharacteristic Speed => _listcharacteristics[CharacteristicType.Speed];
    public UpgradableCharacteristic Protection => _listcharacteristics[CharacteristicType.Protection];
    public UpgradableCharacteristic MagicalProtection => _listcharacteristics[CharacteristicType.MagicalProtection];
    public UpgradableCharacteristic Intuition => _listcharacteristics[CharacteristicType.Intuition];
    public UpgradableCharacteristic Adaptation => _listcharacteristics[CharacteristicType.Adaptation];
    public UpgradableCharacteristic Inspiration => _listcharacteristics[CharacteristicType.Inspiration];
    public UpgradableCharacteristic Composure => _listcharacteristics[CharacteristicType.Composure];
    public UpgradableCharacteristic Teamwork => _listcharacteristics[CharacteristicType.Teamwork];

    public HeroReputation Reputation => _reputation;

    public int AverageValueCharacteristic => (Strenght.Value + Agility.Value + Intellect.Value + Stamina.Value + Magic.Value
                                                + Charisma.Value + Luck.Value + Speed.Value + Protection.Value + MagicalProtection.Value
                                                + Intuition.Value + Adaptation.Value + Inspiration.Value + Composure.Value + Teamwork.Value) / Enum.GetNames(typeof(CharacteristicType)).Length;

    public IReadOnlyList<CharacteristicType> GetCharacteristicTypes()
    {
        return new List<CharacteristicType>(_listcharacteristics.Keys);
    }
}                                       
