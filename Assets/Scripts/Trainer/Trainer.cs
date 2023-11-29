using System;

public class Trainer 
{
    private readonly FullName _fullName;
    private int _age;
    private readonly string _description;
    private readonly IInfo _info;
    private float _learningRate = 1;

    public Trainer(FullName fullname, int age, string description, GeneratorConfig config)
    {
        if(age <= 0 && age > 99) throw new Exception($"There was an attempt to create a Trainer with incorrect parameters (age - {age} correct 1-99)");

        _fullName = fullname;
        _age = age;
        _description = description ?? throw new Exception("There was an attempt to create a Trainer with incorrect parameters (description - null)");

        var builder = new InfoBulder<Info>();
        var director = new TrainerInfoDefMagic(builder, config);
        director.Build();
        _info = builder.GetInfo() ?? throw new Exception("There was an attempt to create a Trainer with incorrect parameters (TrainerState - null)");
    }

    public FullName FullName => _fullName;
    public int Age => _age;
    public string Description => _description;
    public IInfo Info => _info;
    public float LearningRate => _learningRate;

    public void AddProgressCharacteristic(CharacteristicType type, float progress)
    {
        Info.CharacteristicsMap[type].AddProgress(progress);
    }
}
