namespace NIX.OOP.Inheritance;

public class Shape(double width, double height)
{
    public virtual void GetArea()
    {
        Console.WriteLine($"Shape Area: {width * height}");
    }
}