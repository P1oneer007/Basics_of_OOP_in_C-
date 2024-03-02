using System;

public class RationalNumber
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    public static bool operator ==(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
    }

    public static bool operator !=(RationalNumber a, RationalNumber b)
    {
        return !(a == b);
    }

    public static bool operator <(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public static bool operator >(RationalNumber a, RationalNumber b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <=(RationalNumber a, RationalNumber b)
    {
        return a < b || a == b;
    }

    public static bool operator >=(RationalNumber a, RationalNumber b)
    {
        return a > b || a == b;
    }

    public static RationalNumber operator +(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }

    public static RationalNumber operator -(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }

    public static RationalNumber operator *(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    public static RationalNumber operator /(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    public static RationalNumber operator %(RationalNumber a, RationalNumber b)
    {
        return new RationalNumber((a.Numerator / a.Denominator) % (b.Numerator / b.Denominator), a.Denominator * b.Denominator);
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public static implicit operator float(RationalNumber a)
    {
        return (float)a.Numerator / (float)a.Denominator;
    }

    public static implicit operator int(RationalNumber a)
    {
        return a.Numerator / a.Denominator;
    }
}
