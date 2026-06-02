namespace Nix.Oop.Interfaces.AbstractClasses;

public class Dog : Animal, IAnimal
{
    public override void Sound()
    {
        Console.WriteLine("Woof!");
    }
    public void Run()
    {
        Console.WriteLine("The dog is running.");
    }
    public void Eat()
    {
        Console.WriteLine("The dog is eating.");
    }
    public void Sleep()
    {
        Console.WriteLine("The dog is sleeping.");
    }
}