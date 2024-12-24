using RoutineTracker.API.Model;

namespace RoutineTracker.API.Repository;

public interface ICategoryRepository
{
    Category CreateCategory(Category newCategory);
    IEnumerable<Category> GetAllCategoriesByUserId(int userId);
    Category? GetCategoryById(int id);
    Category? UpdateCategoryById(int id, Category updatedCategory);
    Category? AddItemToCategory(int categoryId, int itemId);
    Category? DeleteCategoryById(int id);
}