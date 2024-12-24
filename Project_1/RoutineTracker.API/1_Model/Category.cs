namespace RoutineTracker.API.Model;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public List<Item>? Items { get; set; }
    public int UserId { get; internal set; }
}