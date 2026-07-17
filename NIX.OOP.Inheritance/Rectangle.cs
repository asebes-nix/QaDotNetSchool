namespace NIX.OOP.Inheritance;

public class Rectangle(double width, double height) : Shape(width, height)
{
    public override void GetArea()
    {
        Console.WriteLine($"Rectangle Area: {width * height}");
    }
}