using System;

public interface IShape
{
    void MoveHorizontal(int distance);
    void MoveVertical(int distance);
    void ChangeColor(string newColor);
    void CheckVisibility();
}

public abstract class Figure : IShape
{
    protected string color;
    protected bool isVisible;

    public Figure(string color, bool isVisible)
    {
        this.color = color;
        this.isVisible = isVisible;
    }

    public virtual void MoveHorizontal(int distance)
    {
        Console.WriteLine($"Moving {GetType().Name} {distance} units horizontally.");
    }

    public virtual void MoveVertical(int distance)
    {
        Console.WriteLine($"Moving {GetType().Name} {distance} units vertically.");
    }

    public virtual void ChangeColor(string newColor)
    {
        color = newColor;
        Console.WriteLine($"Color changed to {color} for {GetType().Name}.");
    }

    public virtual void CheckVisibility()
    {
        string visibility = isVisible ? "visible" : "invisible";
        Console.WriteLine($"{GetType().Name} is {visibility}.");
    }

    public abstract void DisplayInfo();
}

public class Point : Figure
{
    public Point(string color, bool isVisible) : base(color, isVisible)
    {
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Point - Color: {color}, Visibility: {isVisible}");
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

    public override void DisplayInfo()
    {
        Console.WriteLine($"Circle - Color: {color}, Visibility: {isVisible}");
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

    public override void DisplayInfo()
    {
        Console.WriteLine($"Rectangle - Color: {color}, Visibility: {isVisible}");
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