using System;
using System.Collections.Generic;

public class FileManager
{
    private List<string> disks = new List<string>();
    private List<string> folders = new List<string>();
    private List<string> files = new List<string>();

    public void ShowDisks()
    {
        foreach (string disk in disks)
        {
            Console.WriteLine($"Disk: {disk}");
        }
    }

    public void CreateFolder(string folderName)
    {
        folders.Add(folderName);
        Console.WriteLine($"Folder '{folderName}' created.");
    }

    public void CreateFile(string fileName)
    {
        files.Add(fileName);
        Console.WriteLine($"File '{fileName}' created.");
    }

    public void DeleteFolder(string folderName)
    {
        if (folders.Contains(folderName))
        {
            folders.Remove(folderName);
            Console.WriteLine($"Folder '{folderName}' deleted.");
        }
        else
        {
            Console.WriteLine($"Folder '{folderName}' not found.");
        }
    }

    public void DeleteFile(string fileName)
    {
        if (files.Contains(fileName))
        {
            files.Remove(fileName);
            Console.WriteLine($"File '{fileName}' deleted.");
        }
        else
        {
            Console.WriteLine($"File '{fileName}' not found.");
        }
    }

    public void RenameFolder(string oldName, string newName)
    {
        if (folders.Contains(oldName))
        {
            int index = folders.IndexOf(oldName);
            folders[index] = newName;
            Console.WriteLine($"Folder '{oldName}' renamed to '{newName}'.");
        }
        else
        {
            Console.WriteLine($"Folder '{oldName}' not found.");
        }
    }

    public void RenameFile(string oldName, string newName)
    {
        if (files.Contains(oldName))
        {
            int index = files.IndexOf(oldName);
            files[index] = newName;
            Console.WriteLine($"File '{oldName}' renamed to '{newName}'.");
        }
        else
        {
            Console.WriteLine($"File '{oldName}' not found.");
        }
    }

    // Other methods like Copy, Move, CalculateSize, SearchByMask, TextFileStats can be added here
}

class Program
{
    static void Main()
    {
        FileManager fileManager = new FileManager();

        fileManager.ShowDisks();
        fileManager.CreateFolder("Documents");
        fileManager.CreateFile("Document1.txt");
        fileManager.DeleteFolder("Downloads");
        fileManager.DeleteFile("Image.jpg");
        fileManager.RenameFolder("Photos", "Pictures");
        fileManager.RenameFile("Report.docx", "Summary.docx");
    }
}