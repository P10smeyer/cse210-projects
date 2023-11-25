using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("Blue", 2);
        Console.WriteLine(square.GetColor());
        Console.WriteLine(square.GetArea());

        Rectangle rectangle = new Rectangle("Red", 5, 6);

        Circle circle = new Circle("Green", 3);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            
            Console.WriteLine($"The {color} shape has an area of of {area}.");
        }
    }
}