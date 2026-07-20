namespace Nix.Oop.Generics;

public class User(int userId, int balance)
{
    public int UserId => userId;

    public int Balance { get; set; } = balance;
}