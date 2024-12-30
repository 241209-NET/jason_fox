using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Service;

public interface ICategoryService
{
    Category CreateCategory(CategoryInDTO newCategory);
    IEnumerable<Category> GetAllCategoriesByUserId(int userId);
    Category? GetCategoryById(int id);
    Category? UpdateCategoryById(int id, CategoryInDTO updatedCategory);
    Category? DeleteCategoryById(int id);
}