// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

class MiniProject
{
    static readonly List<string> modifiedStrings = new List<string>();

    public static void Main(string[] args)
    {
        bool showMenu = true;
        while (showMenu)
        {
            showMenu = MainMenu();
        }
    }

    private static bool MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Reverse String");
        Console.WriteLine("2) Remove Whitespace");
        Console.WriteLine("3) View All");
        Console.WriteLine("4) Clear All");
        Console.WriteLine("5) Output to File");
        Console.WriteLine("6) Exit");

        switch (Console.ReadLine())
        {
            case "1":
                ReverseString();
                return true;
            case "2":
                RemoveWhitespace();
                return true;
            case "3":
                ViewAll();
                return true;
            case "4":
                ClearAll();
                return true;
            case "5":
                OutputToFile();
                return true;
            case "6":
                return false;
            default:
                return true;
        }
    }

    private static string GetInput(string prompt)
    {
        string? input = "";
        while (String.IsNullOrEmpty(input) || String.IsNullOrWhiteSpace(input))
        {
            Console.Clear();
            Console.WriteLine(prompt);
            input = Console.ReadLine();
        }
        return input;
    }

    private static string PromptReturnToMenu()
    {
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
        return "";
    }

    private static bool ListIsEmpty()
    {
        if (modifiedStrings.Count == 0)
        {
            Console.WriteLine("List of modified strings is currently empty.");
            PromptReturnToMenu();
            return true;
        }
        return false;
    }

    private static void ReverseString()
    {
        string input = GetInput("Enter a string to reverse:");
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string output = new(charArray);
        Console.WriteLine($"Reversed string: {output}");
        modifiedStrings.Add($"{input} => {output}");
        PromptReturnToMenu();
        return;
    }

    private static void RemoveWhitespace()
    {
        string input = GetInput("Enter a string to remove whitespace:");
        string output = input.Replace(" ", "");
        Console.WriteLine($"String with whitespace removed: {output}");
        modifiedStrings.Add($"{input} => {output}");
        PromptReturnToMenu();
        return;
    }

    private static void ViewAll()
    {
        if (ListIsEmpty()) return;
        Console.WriteLine("Modified strings:");
        foreach (string s in modifiedStrings)
        {
            Console.WriteLine(s);
        }
        PromptReturnToMenu();
        return;
    }

    private static void ClearAll()
    {
        if (ListIsEmpty()) return;
        modifiedStrings.Clear();
        Console.WriteLine("All modified strings cleared.");
        PromptReturnToMenu();
        return;
    }

    private static void OutputToFile()
    {
        if (ListIsEmpty()) return;
        Console.WriteLine("Outputting modified strings to file...");
        long startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        string path = Path.Combine(Directory.GetCurrentDirectory(), "dist");
        string fileName = "modified_strings.txt";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string[] lines = modifiedStrings.ToArray();
        File.AppendAllLines(Path.Combine(path, fileName), lines);
        long endTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        Console.WriteLine($"Output complete in {endTime - startTime}ms, see dist/{fileName}");
        PromptReturnToMenu();
    }
}