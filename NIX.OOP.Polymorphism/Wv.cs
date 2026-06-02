namespace Nix.Oop.Polymorphism;

public class Wv : Car
{
    public override void GetQuantity()
    {
        Console.WriteLine($"{quantity} Wolksvagen cars ready for operation");
    }

    public sealed override void GetFullInfo()
    {
        Console.WriteLine($"{quantity} Wolksvagen cars ready for operation and {warranty} years warranty");
    }

    public void GetFullInfo(string color)
    {
        Console.WriteLine($"{quantity} Wolksvagen cars ready for operation, color: {color}, and {warranty} years warranty");
    }  
}