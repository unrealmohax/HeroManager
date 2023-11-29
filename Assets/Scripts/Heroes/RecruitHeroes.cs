using System;
using System.Collections.Generic;
using System.Linq;

internal class RecruitHeroes
{
    private readonly GeneratorConfig _config;

    public RecruitHeroes(GeneratorConfig config)
    {
        _config = config;
    }

    public List<Hero> Recruiting(IEnumerable<FullName> fullNames) 
    {
        int heroCount = new Random().Next(3, 5);
        List <Hero> heroes = new List<Hero>();

        for (int i = 0; i < heroCount; i++)
        {
            IEnumerable<FullName> fullNamesRecruit  = heroes.Select(h=> h.FullName).ToList();
            Hero hero = GetHero(fullNames, fullNamesRecruit);
            heroes.Add(hero);
        }

        return heroes;
    }

    private Hero GetHero(IEnumerable<FullName> fullNames, IEnumerable<FullName> fullNamesRecruit)
    {
        FullName fullName = new FullName("Andrey", "Panchenko");
        
        IEnumerable<FullName> combined = fullNames.Concat(fullNamesRecruit);
        List<FullName> listFullName = new List<FullName>(combined);

        while (listFullName.Contains(fullName)) 
        {
            fullName.SecondName += "1";
        }

        return new(fullName, 30, 30, _config);
    }
}

