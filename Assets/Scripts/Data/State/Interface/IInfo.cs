using System.Collections.Generic;

public interface IInfo
{
    IReadOnlyDictionary<CharacteristicType, UpgradableCharacteristic> CharacteristicsMap { get; }
    IReadOnlyList<CharacteristicType> GetCharacteristicTypes();
    bool AddCharacteristic(CharacteristicType type, UpgradableCharacteristic UpgradableCharacteristic);
}
