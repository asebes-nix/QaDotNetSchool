namespace Nix.Oop.Interfaces.AbstractClasses;

public class Cat : Animal, IRunable, IEscapable, IEatable, ISleepable
{
    public override void Sound()
    {
        Console.WriteLine("Meow!");
    }

    void IRunable.Run()
    {
        Console.WriteLine("The cat is running.");
    }

    void IEscapable.Run()
    {
        Console.WriteLine("The cat is escaping!");
    }

    void IEatable.Eat()
    {
        Console.WriteLine("The cat is eating.");
    }

    void ISleepable.Sleep()
    {
        Console.WriteLine("The cat is sleeping.");
    }
}
