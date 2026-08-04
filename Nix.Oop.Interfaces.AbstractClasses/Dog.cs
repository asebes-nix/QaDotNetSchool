namespace Nix.Oop.Interfaces.AbstractClasses;

public class Dog : Animal, IAnimal, IEscapable
{
    public override void Sound()
    {
        Console.WriteLine("Woof!");
    }

    void IRunable.Run()
    {
        Console.WriteLine("The dog is running.");
    }

    void IEscapable.Run()
    {
        Console.WriteLine("The dog is escaping!");
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