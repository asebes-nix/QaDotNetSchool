namespace Nix.Oop.Interfaces.AbstractClasses;

public class Cat : Animal, IAnimal, IEscapable
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

    public void Eat()
    {
        Console.WriteLine("The cat is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("The cat is sleeping.");
    }
}
