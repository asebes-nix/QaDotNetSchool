namespace Nix.OOP.ObjectsClassesStructures;

public class User(int id, string name, int age)
{
    private readonly int _userID = id;
    private readonly string _name = name;
    private int _age = age;

    public void PrintInfo()
    {
        Console.WriteLine($"ID: {_userID}, Name: {_name}, Age: {_age}");
    }

    public static void ChangeUserAge(User user, int newAge)
    {
        user._age = newAge;
    }
}
