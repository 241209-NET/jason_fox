using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Service;

public interface ICategoryService
{
    Category CreateCategory(CategoryInDTO newCategory);
    Category? GetCategoryById(int id);
    Category? UpdateCategoryById(int id, CategoryInDTO updatedCategory);
    Category? AddItemToCategory(int categoryId, int itemId);
    Category? DeleteCategoryById(int id);
}