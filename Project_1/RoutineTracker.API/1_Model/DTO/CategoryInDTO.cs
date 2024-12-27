using RoutineTracker.API.Model;

namespace RoutineTracker.API.DTO;

public class CategoryInDTO
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public required int UserId { get; set; }

    public Category ToCategory()
    {
        return new Category
        {
            Name = this.Name,
            Description = this.Description,
            UserId = this.UserId
        };
    }
}