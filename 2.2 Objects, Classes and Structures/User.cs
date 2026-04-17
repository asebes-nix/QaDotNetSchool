namespace Objects_Classes_Structures;

public class User
{
    public int UserID;
    public string Name;
    public int Age;
    public User(int id, string name, int age)
    {
        UserID = id;
        Name = name;
        Age = age;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"ID: {UserID}, Name: {Name}, Age: {Age}");
    }

    public static void ChangeUserAge(User user, int newAge)
    {
        user.Age = newAge;
    }
}