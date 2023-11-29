using System;

public class Hero : IPersonInfo
{
    public readonly IHeroInfo Info;
    private FullName _fullName;
    private int _age;

    public Hero(FullName fullName, int Age, int value, GeneratorConfig config)
    {
        _fullName = fullName;

        if (Age < 13 || Age > 99)
        {
            throw new Exception($"There was an attempt to create a hero with incorrect parameters (Age - {Age})");
        }

        _age = Age;

        if (value <= 0) throw new Exception("There was an attempt to create a hero with incorrect parameters (value, maxValue - incorrect)");

        var builder = new InfoBulder<HeroInfo>();
        var director = new HeroInfoDirector(builder, config);
        director.Build(value);
        Info = (IHeroInfo)builder.GetInfo() ?? throw new Exception("There was an attempt to create a hero with incorrect parameters (State - null)");
    }

    public FullName FullName => _fullName;
    public int Age => _age;

    public void AddProgressCharacteristic(CharacteristicType type, float progress) 
    {
        Info.CharacteristicsMap[type].AddProgress(progress);
    }
}