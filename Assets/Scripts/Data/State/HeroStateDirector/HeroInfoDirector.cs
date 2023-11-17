public class HeroInfoDirector 
{
    private readonly IInfoBulder _heroInfoBulder;
    private readonly GeneratorUpgradbleCharacteristic _generator;
    private const int MIN_VALUE_CHANCE = 1;

    public HeroInfoDirector(IInfoBulder heroStateBulder, GeneratorConfig config)
    {
        _heroInfoBulder = heroStateBulder;
        _generator = new(config);
    }

    public void Build(int value = MIN_VALUE_CHANCE)
    {
        _heroInfoBulder.AddCharacteristic(CharacteristicType.Strenght, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Agility, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Intellect, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Stamina, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Magic, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Charisma, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Luck, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Speed, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Protection, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.MagicalProtection, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Intuition, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Adaptation, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Inspiration, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Composure, _generator.Generate(value))
                        .AddCharacteristic(CharacteristicType.Teamwork, _generator.Generate(value));
    }
}
