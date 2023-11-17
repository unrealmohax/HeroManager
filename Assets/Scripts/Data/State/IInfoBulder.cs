public interface IInfoBulder 
{
    IInfoBulder AddCharacteristic(CharacteristicType type, CharacteristicValue value);
    IInfo GetState();
}
