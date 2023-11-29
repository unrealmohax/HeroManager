using UnityEngine;

public abstract class ImprovementRoomConfig : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public CharacteristicType[] CharacteristicType { get; private set; }
}