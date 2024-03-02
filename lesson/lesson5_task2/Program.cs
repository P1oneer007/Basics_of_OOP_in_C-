public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }

    public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
    {
        double realPart = a.Real * b.Real - a.Imaginary * b.Imaginary;
        double imaginaryPart = a.Real * b.Imaginary + a.Imaginary * b.Real;
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public static bool operator ==(ComplexNumber a, ComplexNumber b)
    {
        return a.Real == b.Real && a.Imaginary == b.Imaginary;
    }

    public static bool operator !=(ComplexNumber a, ComplexNumber b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}

class Program
{
    static void Main()
    {
        ComplexNumber num1 = new ComplexNumber(2, 3);
        ComplexNumber num2 = new ComplexNumber(1, 2);

        Console.WriteLine($"Complex Number 1: {num1}");
        Console.WriteLine($"Complex Number 2: {num2}");

        Console.WriteLine($"Sum: {num1 + num2}");
        Console.WriteLine($"Difference: {num1 - num2}");
        Console.WriteLine($"Product: {num1 * num2}");

        Console.WriteLine($"Are they equal? {num1 == num2}");
    }
}