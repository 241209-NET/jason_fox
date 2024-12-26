using RoutineTracker.API.Model;

namespace RoutineTracker.API.DTO;

public class ItemInDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly? LastDate { get; set; }
    public DateOnly? NextDate { get; set; }
    public int? Frequency { get; set; }
    public int? CategoryId { get; set; }

    public Item ToItem()
    {
        return new Item
        {
            Name = this.Name,
            Description = this.Description,
            LastDate = this.LastDate,
            NextDate = this.NextDate,
            Frequency = this.Frequency,
            CategoryId = this.CategoryId
        };
    }
}