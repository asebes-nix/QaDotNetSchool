namespace Nix.Oop.Polymorphism;

public class Audi : Wv
{
    public override void GetQuantity()
    {
        Console.WriteLine($"{quantity} Audi cars ready for operation");
    }

    public new void GetFullInfo(string model)
    {
        Console.WriteLine($"{quantity} Audi cars ready for operation, model: {model}, and {warranty} years warranty");
    }
}