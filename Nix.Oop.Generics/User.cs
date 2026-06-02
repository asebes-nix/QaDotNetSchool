namespace Nix.Oop.Generics;

public class User
{
    private int _userId;
    private int _balance;

    public int UserId
    {
        get { return _userId; }
        set { _userId = value; }
    }
    public int Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }

    public User(int userId, int balance)
    {
        _userId = userId;
        _balance = balance;
    }
}