// See https://aka.ms/new-console-template for more information
namespace oop;

public class Vehicle : IVehicle
{
    public string Brand { get; }
    public string Model { get; }
    public int Year { get; }
    public string Color { get; set; }
    public double Price { get; set; }
    public string Description => $"{Year} {Brand} {Model} in {Color} for ${Price}";
    public bool IsOn { get; private set; } = false;

    public Vehicle(string brand, string model, int year, string color, double price)
    {
        Brand = brand;
        Model = model;
        Year = year;
        Color = color;
        Price = price;
    }

    public void Honk()
    {
        Console.WriteLine("Honk! Honk!");
    }

    public bool Start()
    {
        if (IsOn)
        {
            Console.WriteLine("The vehicle is already on.");
            return false;
        }
        IsOn = true;
        Console.WriteLine("The vehicle is now on.");
        return true;
    }

    public bool Stop()
    {
        if (!IsOn)
        {
            Console.WriteLine("The vehicle is already off.");
            return false;
        }
        IsOn = false;
        Console.WriteLine("The vehicle is now off.");
        return true;
    }
}
