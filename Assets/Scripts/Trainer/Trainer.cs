using System;

public class Trainer 
{
    private readonly string _firstName;
    private readonly string _secondName;
    private int _age;
    private readonly string _description;
    private readonly IInfo _info;

    public Trainer(string firstName, string secondName, int age, string description, GeneratorConfig config)
    {
        if(age <= 0 && age > 99) throw new Exception($"There was an attempt to create a Trainer with incorrect parameters (age - {age} correct 1-99)");

        _firstName = firstName ?? throw new Exception("There was an attempt to create a Trainer with incorrect parameters (firstName - null)");
        _secondName = secondName ?? throw new Exception("There was an attempt to create a Trainer with incorrect parameters (secondName - null)");
        _age = age;
        _description = description ?? throw new Exception("There was an attempt to create a Trainer with incorrect parameters (description - null)");

        var builder = new InfoBulder();
        var director = new TrainerInfoDefMagic(builder, config);
        director.Build();
        _info = builder.GetInfo() ?? throw new Exception("There was an attempt to create a Trainer with incorrect parameters (TrainerState - null)");
    }

    public string FirstName => _firstName;
    public string SecondName => _secondName;
    public int Age => _age;
    public string Description => _description;
    public IInfo Info => _info;
}
