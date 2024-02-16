using System;

public class StringManipulator
{
    public static string ReverseString(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}

class Program
{
    static void Main()
    {
        string input = "Hello, world!";
        string reversed = StringManipulator.ReverseString(input);
        Console.WriteLine(reversed);
    }
}