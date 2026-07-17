namespace Nix.Oop.Generics;

public class User(int userId, int balance)
{
    public int UserId
    {
        get { return userId; }
    }

    public int Balance
    {
        get { return balance; }
    }
}