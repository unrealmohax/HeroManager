using System.Collections.Generic;

public interface IInfo
{
    IReadOnlyDictionary<CharacteristicType, UpgradableCharacteristic> CharacteristicsMap { get; }
    IReadOnlyList<CharacteristicType> GetCharacteristicTypes();
    void AddCharacteristic(CharacteristicType type, UpgradableCharacteristic upgradableCharacteristic);
}
