namespace oop;

public interface IVehicle 
{
    string Brand { get; }
    string Model { get; }
    int Year { get; }
    string Color { get; set; }
    double Price { get; set; }
    string Description { get; }
    bool IsOn { get; }
    bool Start();
    bool Stop();
    void Honk();
}