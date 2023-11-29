using System;
using System.Collections.Generic;
using System.Linq;

internal class RecruitTrainers
{
    private readonly GeneratorConfig _config;

    public RecruitTrainers(GeneratorConfig config)
    {
        _config = config;
    }

    public List<Trainer> Recruiting(IEnumerable<FullName> fullNames)
    {
        int trainerCount = new Random().Next(3, 5);
        List<Trainer> trainers = new List<Trainer>();

        for (int i = 0; i < trainerCount; i++)
        {
            IEnumerable<FullName> fullNamesRecruit = trainers.Select(h => h.FullName).ToList();
            Trainer trainer = GetTrainer(fullNames, fullNamesRecruit);
            trainers.Add(trainer);
        }

        return trainers;
    }

    private Trainer GetTrainer(IEnumerable<FullName> fullNames, IEnumerable<FullName> fullNamesRecruit)
    {
        FullName fullName = new FullName("Andrey", "Panchenko");

        IEnumerable<FullName> combined = fullNames.Concat(fullNamesRecruit);
        List<FullName> listFullName = new List<FullName>(combined);

        while (listFullName.Contains(fullName))
        {
            fullName.SecondName += "1";
        }

        return new(fullName, 30,"", _config);
    }
}

