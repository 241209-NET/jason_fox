namespace RoutineTracker.API.Model;

public class Item
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? LastDate { get; set; }
    public DateOnly? NextDate { get; set; }
    public string? Frequency { get; set; }

    public int? CategoryId { get; set; }
}