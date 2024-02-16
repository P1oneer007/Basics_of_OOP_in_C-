using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        string[] lines = File.ReadAllLines(inputFile);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                string email = ExtractEmail(line);
                if (!string.IsNullOrEmpty(email))
                {
                    writer.WriteLine(email);
                }
            }
        }
    }

    static string ExtractEmail(string input)
    {
        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        Match match = Regex.Match(input, pattern);
        return match.Value;
    }
}