namespace Nix.Oop.Generics;

public class Provider<U> where U : User
{
    public void CheckBalance(U user)
    {
        Console.WriteLine($"User {user.UserId} has a balance of {user.Balance}.");
    }
}