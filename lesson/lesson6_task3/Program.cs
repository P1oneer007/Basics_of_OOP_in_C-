using System;

public class Figure
{
    protected string color;
    protected bool isVisible;

    public Figure(string color, bool isVisible)
    {
        this.color = color;
        this.isVisible = isVisible;
    }

    public void MoveHorizontal(int distance)
    {
        Console.WriteLine($"Moving {distance} units horizontally.");
    }

    public void MoveVertical(int distance)
    {
        Console.WriteLine($"Moving {distance} units vertically.");
    }

    public void ChangeColor(string newColor)
    {
        color = newColor;
        Console.WriteLine($"Color changed to {color}.");
    }

    public void CheckVisibility()
    {
        string visibility = isVisible ? "visible" : "invisible";
        Console.WriteLine($"The figure is {visibility}.");
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Color: {color}, Visibility: {isVisible}");
    }
}

public class Point : Figure
{
    public Point(string color, bool isVisible) : base(color, isVisible)
    {
    }
}

public class Circle : Point
{
    public Circle(string color, bool isVisible) : base(color, isVisible)
    {
    }

    public double CalculateArea()
    {
        // Assuming radius is 1 for simplicity
        return Math.PI * Math.Pow(1, 2);
    }
}

public class Rectangle : Point
{
    public Rectangle(string color, bool isVisible) : base(color, isVisible)
    {
    }

    public double CalculateArea()
    {
        // Assuming sides are 1 and 2 for simplicity
        return 1 * 2;
    }
}

class Program
{
    static void Main()
    {
        Point point = new Point("Red", true);
        Circle circle = new Circle("Blue", true);
        Rectangle rectangle = new Rectangle("Green", true);

        point.MoveHorizontal(5);
        circle.MoveVertical(3);
        rectangle.ChangeColor("Yellow");

        Console.WriteLine("Point Info:");
        point.DisplayInfo();

        Console.WriteLine("Circle Area:");
        Console.WriteLine(circle.CalculateArea());

        Console.WriteLine("Rectangle Area:");
        Console.WriteLine(rectangle.CalculateArea());
    }
}