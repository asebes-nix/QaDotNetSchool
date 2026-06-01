using NIX.OOP.Inheritance;

Shape shape = new Shape(10, 20);   
Shape rectangle = new Rectangle(8, 8);
shape.GetArea();
((Rectangle)rectangle).GetArea();

Shape shape1 = new Rectangle(5, 10);

if (shape1 is Rectangle rect1)
{
    rect1.GetArea();
}

Shape shape2 = new Rectangle(3, 7);

Rectangle? rect2 = shape2 as Rectangle;
if (rect2 != null)
{
    rect2.GetArea();
}

Console.ReadKey();  