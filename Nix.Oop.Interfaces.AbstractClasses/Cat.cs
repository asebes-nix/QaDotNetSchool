namespace Nix.Oop.Interfaces.AbstractClasses;

public class Cat : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Meow!");
    }

    public override void Run()
    {
        Console.WriteLine("The cat is running.");
    }

    public override void Eat()
    {
        Console.WriteLine("The cat is eating.");
    }

    public override void Sleep()
    {
        Console.WriteLine("The cat is sleeping.");
    }
}
