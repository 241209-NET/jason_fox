using RoutineTracker.API.Model;

namespace RoutineTracker.API.DTO;

public class ItemInDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }

    public Item ToItem()
    {
        return new Item
        {
            Name = this.Name,
            Description = this.Description,
        };
    }
}