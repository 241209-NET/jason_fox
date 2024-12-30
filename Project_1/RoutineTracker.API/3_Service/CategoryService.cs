using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;
using RoutineTracker.API.Repository;

namespace RoutineTracker.API.Service;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Category CreateCategory(CategoryInDTO newCategory)
    {
        var category = newCategory.ToCategory();
        return _categoryRepository.CreateCategory(category);
    }

    public IEnumerable<Category> GetAllCategoriesByUserId(int userId)
    {
        return _categoryRepository.GetAllCategoriesByUserId(userId);
    }

    public Category? GetCategoryById(int id)
    {
        return _categoryRepository.GetCategoryById(id);
    }

    public Category? UpdateCategoryById(int id, CategoryInDTO updatedCategory)
    {
        var category = updatedCategory.ToCategory();
        return _categoryRepository.UpdateCategoryById(id, category);
    }

    public Category? DeleteCategoryById(int id)
    {
        return _categoryRepository.DeleteCategoryById(id);
    }
}