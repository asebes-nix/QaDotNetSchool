namespace Nix.Oop.Polymorphism;

public class Wv : Car
{
    public override void GetQuantity()
    {
        Console.WriteLine($"{quantity} Volkswagen cars ready for operation");
    }

    public sealed override void GetFullInfo()
    {
        Console.WriteLine($"{quantity} Volkswagen cars ready for operation and {warranty} years warranty");
    }

    public void GetFullInfo(string color)
    {
        Console.WriteLine($"{quantity} Volkswagen cars ready for operation, color: {color}, and {warranty} years warranty");
    }  
}