namespace oop;

public class Truck : Vehicle
{
    public int LoadCapacity { get; set; }
    public int TowingCapacity { get; set; }

    public Truck(string brand, string model, int year, string color, double price, int loadCapacity, int towingCapacity)
        : base(brand, model, year, color, price)
    {
        LoadCapacity = loadCapacity;
        TowingCapacity = towingCapacity;
    }

    public void Haul(int loadSize)
    {
        if (loadSize > LoadCapacity)
        {
            Console.WriteLine("The truck cannot haul that much weight.");
            return;
        }
        Console.WriteLine("Hauling...");
    }

    public void Tow(int towSize)
    {
        if (towSize > LoadCapacity)
        {
            Console.WriteLine("The truck cannot tow that much weight.");
            return;
        }
        Console.WriteLine("Towing...");
    }
}