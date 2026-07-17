namespace Nix.Oop.Interfaces.AbstractClasses;

public class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Woof!");
    }

    public override void Run()
    {
        Console.WriteLine("The dog is running.");
    }

    public override void Eat()
    {
        Console.WriteLine("The dog is eating.");
    }

    public override void Sleep()
    {
        Console.WriteLine("The dog is sleeping.");
    }
}