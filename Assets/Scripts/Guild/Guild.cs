using System.Collections.Generic;
using System.Linq;

public class Guild
{
    private string _name;

    private GuildData _data;

    public Guild(string name)
    {
        _name = name;
        _data = new GuildData();
    }

    public void RecruitHero(GeneratorConfig heroConfig) 
    {
        RecruitHeroes recruitHeroes = new RecruitHeroes(heroConfig);

        List<FullName> firstNamesList = _data.Heroes.Select(hero => hero.FullName).ToList();
        var heroes = recruitHeroes.Recruiting(firstNamesList);

        foreach (var hero in heroes)
        {
            _data.AddHero(hero);
        }
    }

    public void RecruitTrainer(GeneratorConfig heroConfig)
    {
        RecruitTrainers recruitTrainers = new RecruitTrainers(heroConfig);

        List<FullName> firstNamesList = _data.Heroes.Select(hero => hero.FullName).ToList();
        var trainers = recruitTrainers.Recruiting(firstNamesList);

        foreach (var trainer in trainers)
        {
            _data.AddTrainer(trainer);
        }
    }

    public void CreateRoom() 
    {
        
        /*ImprovementRoom improvementRoom = new Barracks(config, _data.HeroesMap);
        _data.AddImprovementRoom(improvementRoom);*/
    }

    public string Name => _name;
    internal GuildData Data => _data;
}
