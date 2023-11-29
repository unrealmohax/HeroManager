using System.Collections.Generic;

internal class GuildData : IGuildData
{
    private readonly Dictionary<string, Hero> _heroMap;
    private readonly Dictionary<string, Trainer> _trainerMap;
    private readonly Dictionary<string, ImprovementRoom> _improvementRoomMap;

    public GuildData()
    {
        _heroMap = new Dictionary<string, Hero>();
        _trainerMap = new Dictionary<string, Trainer>();
        _improvementRoomMap = new Dictionary<string, ImprovementRoom>();
    }

    public IReadOnlyDictionary<string, Hero> HeroesMap => _heroMap;
    public List<Hero> Heroes => new List<Hero>(_heroMap.Values);
    public IReadOnlyDictionary<string, Trainer> TrainersMap => _trainerMap;
    public List<Trainer> Trainers => new List<Trainer>(_trainerMap.Values);
    public IReadOnlyDictionary<string, ImprovementRoom> ImprovementRoomMap => _improvementRoomMap;
    public List<ImprovementRoom> ImprovementRooms => new List<ImprovementRoom>(_improvementRoomMap.Values);

    internal void AddHero(Hero hero)
    {
        _heroMap.Add(hero.FullName.ToString(), hero);
    }

    internal void AddTrainer(Trainer trainer)
    {
        _trainerMap.Add(trainer.FullName.ToString(), trainer);
    }

    internal void AddImprovementRoom(ImprovementRoom improvementRoom)
    {
        _improvementRoomMap.Add(improvementRoom.Name, improvementRoom);
    }
}