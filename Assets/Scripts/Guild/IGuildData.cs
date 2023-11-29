using System.Collections.Generic;

internal interface IGuildData
{
    IReadOnlyDictionary<string, Hero> HeroesMap { get; }
    IReadOnlyDictionary<string, Trainer> TrainersMap { get; }
    IReadOnlyDictionary<string, ImprovementRoom> ImprovementRoomMap { get; }
    List<Hero> Heroes{ get; }
    List<Trainer> Trainers { get; }
    List<ImprovementRoom> ImprovementRooms { get; }
}