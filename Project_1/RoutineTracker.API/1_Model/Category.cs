namespace RoutineTracker.API.Model;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public List<Item>? Items { get; set; }
}