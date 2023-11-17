public static class CharacteristicsDB 
{
    public static Characteristic[] Characteristics = new Characteristic[]
    {
        new (CharacteristicType.Strenght, "����", "���������� ���������� ���� ���������"),
        new (CharacteristicType.Agility, "��������", "������ �� ����������, ��������� � �������� ���� � ���"),
        new (CharacteristicType.Intellect, "���������", "������ �� ����������� � ��������, ������������� ����� � ������� �����������"),
        new (CharacteristicType.Stamina, "�������������", "�������� �� ����� �������� � ��������� ��������� � ���������"),
        new (CharacteristicType.Magic, "�����", "��������� ���������� ���� � ����������� ������������� ����������"),
        new (CharacteristicType.Charisma, "�������", "������ �� �������, ����������� �������� � ������ �� ������ ����������"),
        new (CharacteristicType.Luck, "�����", "������ �� ����� �������� �������� � ��������� ���������"),
        new (CharacteristicType.Speed, "��������", "���������� �������� ������������ � ������� ���������"),
        new (CharacteristicType.Protection, "������", "������ �� ���������������� ���������� ������"),
        new (CharacteristicType.MagicalProtection, "���������� �������������", "������ �� ���������������� ���������� ������"),
        new (CharacteristicType.Intuition, "��������", "��������� ������������� ������� � ������������ ������� ������"),
        new (CharacteristicType.Adaptation, "���������", "����������, ��������� ������ �������� ����� ����������������� � ����� ��������� � ������������ �����"),
        new (CharacteristicType.Inspiration, "�����������", "���������� ���������� ���� ���������"),
        new (CharacteristicType.Composure, "������������", "������ �� ����������� ��������� ����������� � ����������� ���������"),
        new (CharacteristicType.Teamwork, "��������� ������", "������ �� ����������� �������� � �������"),
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