namespace NIX.OOP.Inheritance;

public class Shape
{
    public double Width;
    public double Height;

    public Shape(double width, double height)
    {
        Width = width;
        Height = height;
    }   

    public void GetArea()
    {
        Console.WriteLine($"Shape Area: {Width * Height}");
    }
}