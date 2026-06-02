namespace Nix.Oop.Interfaces.AbstractClasses;

public class Cat : Animal, IAnimal
{
    public override void Sound()
    {
        Console.WriteLine("Meow!");
    }
        public void Run()
    {
        Console.WriteLine("The cat is running.");
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
