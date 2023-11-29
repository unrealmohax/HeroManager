using System;

public struct FullName : IEquatable<FullName>
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }

    public FullName(string firstName, string secondName)
    {
        FirstName = firstName;
        SecondName = secondName;
    }

    public bool Equals(FullName other)
    {
        return FirstName == other.FirstName && SecondName == other.SecondName;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj is FullName);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, SecondName);
    }

    public override string ToString()
    {
        return $"{FirstName} {SecondName}";
    }
}