namespace Nix.Oop.Interfaces.AbstractClasses;

public class Dog : Animal, IRunable, IEscapable, IEatable, ISleepable
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

    void IEatable.Eat()
    {
        Console.WriteLine("The dog is eating.");
    }

    void ISleepable.Sleep()
    {
        Console.WriteLine("The dog is sleeping.");
    }
}