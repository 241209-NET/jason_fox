namespace RoutineTracker.API.Model;

public class User
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Item> Items { get; set; }
}