using RoutineTracker.API.Model;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Repository;
using RoutineTracker.API.Service;
using Moq;

namespace RoutineTracker.TEST;

public class CategoryDbFixture : IDisposable
{
    public Mock<ICategoryRepository> MockRepo { get; private set; }
    public CategoryService CategoryService { get; private set; }
    public List<Category> CategoryList { get; private set; } = new List<Category>();
    public Category TestCategory { get; private set; }

    public CategoryDbFixture()
    {
        TestCategory = new Category
        {
            Id = 1,
            Name = "Test",
            Description = "This is a test category",
            UserId = 1
        };

        var UpdatedCategory = new Category
        {
            Id = 1,
            Name = "Updated",
            Description = "This is an updated category",
            UserId = 1
        };

        CategoryList.Add(TestCategory);

        MockRepo = new Mock<ICategoryRepository>();

        // Create category
        MockRepo.Setup(repo => repo.CreateCategory(It.IsAny<Category>())).Callback((Category u) => CategoryList.Add(u)).Returns(TestCategory);

        // Get all categories by user id
        MockRepo.Setup(repo => repo.GetAllCategoriesByUserId(TestCategory.UserId)).Returns(CategoryList);

        // Get category by id
        MockRepo.Setup(repo => repo.GetCategoryById(TestCategory.Id)).Returns(TestCategory);

        // Update category by id
        MockRepo.Setup(repo => repo.UpdateCategoryById(TestCategory.Id, It.IsAny<Category>())).Returns(UpdatedCategory);

        // Delete category by id
        MockRepo.Setup(repo => repo.DeleteCategoryById(TestCategory.Id)).Returns(TestCategory);

        CategoryService = new CategoryService(MockRepo.Object);
    }

    public void Dispose()
    {
    }
}

public class CategoryServiceTests : IClassFixture<CategoryDbFixture>
{
    public CategoryDbFixture fixture;

    public CategoryServiceTests(CategoryDbFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void TestCreateCategory()
    {
        // Arrange
        var newCategory = new CategoryInDTO
        {
            Name = "Test",
            Description = "This is a test category",
            UserId = 1
        };

        // Act
        var result = fixture.CategoryService.CreateCategory(newCategory);

        // Assert
        Assert.Equal(newCategory.Name, result.Name);
        Assert.Equal(newCategory.Description, result.Description);
        Assert.Equal(newCategory.UserId, result.UserId);
    }

    [Fact]
    public void TestGetAllCategoriesByUserId()
    {
        // Arrange
        var userId = 1;

        // Act
        var result = fixture.CategoryService.GetAllCategoriesByUserId(userId);

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(userId, result.First().UserId);
    }

    [Fact]
    public void TestGetCategoryById()
    {
        // Act
        var result = fixture.CategoryService.GetCategoryById(fixture.TestCategory.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestCategory.Id, result.Id);
    }

    [Fact]
    public void TestUpdateCategoryById()
    {
        // Arrange
        var updatedCategory = new CategoryInDTO
        {
            Name = "Updated",
            Description = "This is an updated category",
            UserId = 1
        };

        // Act
        var result = fixture.CategoryService.UpdateCategoryById(fixture.TestCategory.Id, updatedCategory);

        // Assert
        Assert.Equal(updatedCategory.Name, result.Name);
        Assert.Equal(updatedCategory.Description, result.Description);
        Assert.Equal(updatedCategory.UserId, result.UserId);
    }

    [Fact]
    public void TestDeleteCategoryById()
    {
        // Act
        var result = fixture.CategoryService.DeleteCategoryById(fixture.TestCategory.Id);
        
        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestCategory.Id, result.Id);
    }
}