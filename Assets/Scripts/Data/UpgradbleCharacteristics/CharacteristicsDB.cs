public static class CharacteristicsDB 
{
    public static Characteristic[] Characteristics = new Characteristic[]
    {
        new (CharacteristicType.Strenght, "Сила", "Определяет физическую мощь персонажа"),
        new (CharacteristicType.Agility, "Ловкость", "Влияет на проворство, уклонение и точность атак в бою"),
        new (CharacteristicType.Intellect, "Интеллект", "Влияет на способность к обучению, использование магии и решение головоломок"),
        new (CharacteristicType.Stamina, "Выностливость", "казывает на общее здоровье и стойкость персонажа к усталости"),
        new (CharacteristicType.Magic, "Магия", "пределяет магическую мощь и способность использования заклинаний"),
        new (CharacteristicType.Charisma, "Харизма", "Влияет на общение, возможность убеждать и влиять на других персонажей"),
        new (CharacteristicType.Luck, "Удача", "Влияет на шансы успешных действий в случайных ситуациях"),
        new (CharacteristicType.Speed, "Скорость", "Определяет скорость передвижения и реакцию персонажа"),
        new (CharacteristicType.Protection, "Защита", "Влияет на сопротивляемость физическим атакам"),
        new (CharacteristicType.MagicalProtection, "Магическое сопротивление", "Влияет на сопротивляемость магическим атакам"),
        new (CharacteristicType.Intuition, "Интуиция", "Позволяет предсказывать события и обнаруживать скрытые угрозы"),
        new (CharacteristicType.Adaptation, "Адаптация", "Определяет, насколько быстро персонаж может приспосабливаться к новым ситуациям и изменяющейся среде"),
        new (CharacteristicType.Inspiration, "Вдохновение", "Определяет физическую мощь персонажа"),
        new (CharacteristicType.Composure, "Хладнокровие", "Влияет на способность сохранять спокойствие в критических ситуациях"),
        new (CharacteristicType.Teamwork, "Командная работа", "Влияет на способность работать в команде"),
    };
}

public struct Characteristic 
{
    public Characteristic(CharacteristicType Type, string Name, string Description)
    {
        this.Name = Name; 
        this.Description = Description;
        this.Type = Type;
    }

    public string Name;
    public string Description;
    public CharacteristicType Type;
}

public enum CharacteristicType 
{
    Strenght,
    Agility,
    Intellect,
    Stamina,
    Magic,
    Charisma,
    Luck,
    Speed,
    Protection ,
    MagicalProtection ,
    Intuition,
    Adaptation,
    Inspiration,
    Composure,
    Teamwork,
}