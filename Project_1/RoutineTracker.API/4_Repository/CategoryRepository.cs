using RoutineTracker.API.Data;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly RoutineTrackerContext _routineTrackerContext;
    public CategoryRepository(RoutineTrackerContext routineTrackerContext)
    {
        _routineTrackerContext = routineTrackerContext;
    }
    
    public Category CreateCategory(Category newCategory)
    {
        _routineTrackerContext.Categories.Add(newCategory);
        _routineTrackerContext.SaveChanges();
        return newCategory;
    }

    public IEnumerable<Category> GetAllCategoriesByUserId(int userId)
    {
        return _routineTrackerContext.Categories.Where(c => c.UserId == userId);
    }

    public Category? GetCategoryById(int id)
    {
        return _routineTrackerContext.Categories.Find(id);
    }

    public Category? UpdateCategoryById(int id, Category updatedCategory)
    {
        var category = _routineTrackerContext.Categories.Find(id);
        if (category == null) return null;
        category.Name = updatedCategory.Name;
        _routineTrackerContext.SaveChanges();
        return category;
    }

    public Category? DeleteCategoryById(int id)
    {
        var category = _routineTrackerContext.Categories.Find(id);
        if (category == null) return null;
        _routineTrackerContext.Categories.Remove(category);
        _routineTrackerContext.SaveChanges();
        return category;
    }
}