// See https://aka.ms/new-console-template for more information
class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("What is your name?");
        string? input = Console.ReadLine();
        Console.WriteLine($"Hello, {input?.Trim()}!");
    }
}