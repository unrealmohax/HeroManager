using System;

public class Hero 
{
    public readonly IHeroInfo Info;
    private string _firstName;
    private string _secondName;
    private int _age;

    public Hero(string FirstName, string SecondName, int Age, int value, GeneratorConfig config)
    {
        SetParametrs(FirstName, SecondName, Age);

        if (value <= 0) throw new Exception("There was an attempt to create a hero with incorrect parameters (value, maxValue - incorrect)");

        var builder = new InfoBulder<HeroInfo>();
        var director = new HeroInfoDirector(builder, config);
        director.Build(value);
        Info = (IHeroInfo)builder.GetInfo() ?? throw new Exception("There was an attempt to create a hero with incorrect parameters (State - null)");
    }

    public Hero(string FirstName, string SecondName, int Age, HeroInfo heroInfo)
    {
        Info = heroInfo ?? throw new Exception("There was an attempt to create a hero with incorrect parameters (State - null)");
        SetParametrs(FirstName, SecondName, Age);
    }

    private void SetParametrs(string FirstName, string SecondName, int Age)
    {
        _firstName = FirstName ?? throw new Exception("There was an attempt to create a hero with incorrect parameters (FirstName - null)");
        _secondName = SecondName ?? throw new Exception("There was an attempt to create a hero with incorrect parameters (SecondName - null)");

        if (Age < 13 || Age > 99)
        {
            throw new Exception($"There was an attempt to create a hero with incorrect parameters (Age - {Age})");
        }

        _age = Age;
    }

    public string FirstName => _firstName;
    public string SecondName => _secondName;
    public int Age => _age;


    public void AddProgressCharacteristic(CharacteristicType type, float progress) 
    {
        Info.CharacteristicsMap[type].AddProgress(progress);
    }
}