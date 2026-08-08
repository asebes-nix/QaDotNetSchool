namespace Nix.Oop.Interfaces.AbstractClasses;

public interface IAnimal : IRunable, IEatable, ISleepable
{
    void IsAnimal() => Console.WriteLine("I am an animal");
}