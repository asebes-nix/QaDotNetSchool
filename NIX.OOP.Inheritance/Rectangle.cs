namespace NIX.OOP.Inheritance;

public class Rectangle : Shape
{
    public Rectangle(double width, double height) : base(width, height)
    {

    }

    public new void GetArea()
    {
        Console.WriteLine($"Rectangle Area: {Width * Height}");
    }
}