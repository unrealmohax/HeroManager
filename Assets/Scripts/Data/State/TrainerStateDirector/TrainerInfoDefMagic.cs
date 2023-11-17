public class TrainerInfoDefMagic 
{
    private readonly IInfoBulder _trainerInfoBulder;
    private readonly GeneratorUpgradbleCharacteristic _generator;
    private const int MIN_VALUE_CHANCE = 1;

    public TrainerInfoDefMagic(IInfoBulder trainerStateBulder, GeneratorConfig config) 
    { 
        _trainerInfoBulder = trainerStateBulder;
        _generator = new(config);
    }

    public void Build(int value = MIN_VALUE_CHANCE)
    {
        _trainerInfoBulder.AddCharacteristic(CharacteristicType.Magic, _generator.Generate(value))
                    .AddCharacteristic(CharacteristicType.Protection, _generator.Generate(value));
    }
}
