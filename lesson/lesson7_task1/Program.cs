using System;

public interface ICoder
{
    string Encode(string text);
    string Decode(string text);
}

public class ACoder : ICoder
{
    public string Encode(string text)
    {
        char[] chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] + 1);
        }
        return new string(chars);
    }

    public string Decode(string text)
    {
        char[] chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] - 1);
        }
        return new string(chars);
    }
}

public class BCoder : ICoder
{
    public string Encode(string text)
    {
        char[] chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] + 26 - i);
        }
        return new string(chars);
    }

    public string Decode(string text)
    {
        char[] chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] - 26 + i);
        }
        return new string(chars);
    }
}

class Program
{
    static void Main()
    {
        ICoder acoder = new ACoder();
        ICoder bcoder = new BCoder();

        string text = "Hello, World!";

        Console.WriteLine("Original text: " + text);

        string encodedText = acoder.Encode(text);
        Console.WriteLine("ACoder encoded text: " + encodedText);

        string decodedText = acoder.Decode(encodedText);
        Console.WriteLine("ACoder decoded text: " + decodedText);

        encodedText = bcoder.Encode(text);
        Console.WriteLine("BCoder encoded text: " + encodedText);

        decodedText = bcoder.Decode(encodedText);
        Console.WriteLine("BCoder decoded text: " + decodedText);
    }
}