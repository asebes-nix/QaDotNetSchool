namespace Nix.Oop.Polymorphism;

public class Audi : Wv
{
    public override void GetQuantity()
    {
        Console.WriteLine($"{quantity} Audi cars ready for operation");
    }

    public void GetFullInfo(string model, int year)
    {
        Console.WriteLine($"{quantity} Audi cars ready for operation, model: {model}, year: {year}, and {warranty} years warranty");
    }
}