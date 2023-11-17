public interface IHeroInfo : IInfo
{
    UpgradableCharacteristic Strenght { get; }
    UpgradableCharacteristic Agility { get; }
    UpgradableCharacteristic Intellect { get; }
    UpgradableCharacteristic Stamina { get; }
    UpgradableCharacteristic Magic { get; }
    UpgradableCharacteristic Charisma { get; }
    UpgradableCharacteristic Luck { get; }
    UpgradableCharacteristic Speed { get; }
    UpgradableCharacteristic Protection { get; }
    UpgradableCharacteristic MagicalProtection { get; }
    UpgradableCharacteristic Intuition { get; }
    UpgradableCharacteristic Adaptation { get; }
    UpgradableCharacteristic Inspiration { get; }
    UpgradableCharacteristic Composure { get; }
    UpgradableCharacteristic Teamwork { get; }

    HeroReputation Reputation { get; }
    int AverageValueCharacteristic { get; }
}
