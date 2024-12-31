using RoutineTracker.API.Model;
using RoutineTracker.API.DTO;
using RoutineTracker.API.Repository;
using RoutineTracker.API.Service;
using Moq;

namespace RoutineTracker.TEST;

public class ItemDbFixture : IDisposable
{
    public Mock<IItemRepository> MockRepo { get; private set; }
    public ItemService ItemService { get; private set; }
    public List<Item> ItemList { get; private set; } = new List<Item>();
    public Item TestItem { get; private set; }
    public Item TestCategoryItem { get; private set; }

    public ItemDbFixture()
    {
        TestItem = new Item
        {
            Id = 1,
            Name = "Test",
            Description = "This is a test item",
            UserId = 1
        };

        TestCategoryItem = new Item
        {
            Id = 2,
            Name = "Test 2",
            Description = "This is a test category item",
            UserId = 1,
            CategoryId = 1
        };

        var UpdatedItem = new Item
        {
            Id = 1,
            Name = "Updated",
            Description = "This is an updated item",
            UserId = 1,
            NextDate = new DateOnly(2025, 1, 30),
            LastDate = new DateOnly(2024, 12, 31),
            Frequency = 30
        };

        ItemList.Add(TestItem);
        ItemList.Add(TestCategoryItem);

        MockRepo = new Mock<IItemRepository>();

        // Create item
        MockRepo.Setup(repo => repo.CreateItem(It.IsAny<Item>())).Callback((Item u) => ItemList.Add(u)).Returns(TestItem);

        // Get item by id
        MockRepo.Setup(repo => repo.GetItemById(TestItem.Id)).Returns(TestItem);

        // Update item by id
        MockRepo.Setup(repo => repo.UpdateItemById(TestItem.Id, It.IsAny<Item>())).Returns(UpdatedItem);

        // Delete item by id
        MockRepo.Setup(repo => repo.DeleteItemById(TestItem.Id)).Returns(TestItem);

        // Get items by user id
        MockRepo.Setup(repo => repo.GetItemsByUserId(TestItem.UserId)).Returns(ItemList.Where(i => i.UserId == TestItem.UserId));

        // Get items by category id
        MockRepo.Setup(repo => repo.GetItemsByCategoryId(TestCategoryItem.Id)).Returns(ItemList.Where(i => i.CategoryId == TestCategoryItem.CategoryId));

        // Add item to category
        MockRepo.Setup(repo => repo.AddItemToCategory(TestCategoryItem.Id, TestItem.Id)).Returns(
            new Item
            {
                Id = TestItem.Id,
                Name = TestItem.Name,
                Description = TestItem.Description,
                UserId = TestItem.UserId,
                CategoryId = TestCategoryItem.Id
            }
        );

        // Remove item from category
        MockRepo.Setup(repo => repo.RemoveItemFromCategory(TestCategoryItem.Id, TestItem.Id)).Returns(
            new Item
            {
                Id = TestItem.Id,
                Name = TestItem.Name,
                Description = TestItem.Description,
                UserId = TestItem.UserId
            }
        );

        ItemService = new ItemService(MockRepo.Object);
    }

    public void Dispose()
    {
    }
}

public class ItemServiceTests : IClassFixture<ItemDbFixture>
{
    public ItemDbFixture fixture;

    public ItemServiceTests(ItemDbFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public void TestCreateItem()
    {
        // Arrange
        var newItem = new ItemInDTO
        {
            Name = "Test",
            Description = "This is a test item",
            UserId = 1
        };

        // Act
        var result = fixture.ItemService.CreateItem(newItem);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(newItem.Name, result.Name);
        Assert.Equal(newItem.Description, result.Description);
        Assert.Equal(newItem.UserId, result.UserId);
    }

    [Fact]
    public void TestGetItemById()
    {
        // Act
        var result = fixture.ItemService.GetItemById(fixture.TestItem.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestItem.Id, result.Id);
    }

    [Fact]
    public void TestUpdateItemById()
    {
        // Arrange
        var updatedItem = new ItemInDTO
        {
            Name = "Updated",
            Description = "This is an updated item",
            NextDate = new DateOnly(2025, 1, 30),
            LastDate = new DateOnly(2024, 12, 31),
            Frequency = 30,
            UserId = 30
        };

        // Act
        var result = fixture.ItemService.UpdateItemById(fixture.TestItem.Id, updatedItem);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(updatedItem.Name, result.Name);
        Assert.Equal(updatedItem.Description, result.Description);
        Assert.Equal(updatedItem.NextDate, result.NextDate);
        Assert.Equal(updatedItem.LastDate, result.LastDate);
        Assert.Equal(updatedItem.Frequency, result.Frequency);
    }

    [Fact]
    public void TestDeleteItemById()
    {
        // Act
        var result = fixture.ItemService.DeleteItemById(fixture.TestItem.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestItem.Id, result.Id);
    }

    [Fact]
    public void TestGetItemsByUserId()
    {
        // Act
        var result = fixture.ItemService.GetItemsByUserId(fixture.TestItem.UserId);

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(fixture.TestItem.UserId, result.First().UserId);
    }

    [Fact]
    public void TestGetItemsByUserIdEmpty()
    {
        // Act
        var result = fixture.ItemService.GetItemsByUserId(2);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void TestGetItemsByCategoryId()
    {
        // Act
        var result = fixture.ItemService.GetItemsByCategoryId(fixture.TestCategoryItem.Id);

        // Assert
        Assert.NotEmpty(result);
        Assert.All(result, item => Assert.Equal(fixture.TestCategoryItem.CategoryId, item.CategoryId));
    }

    [Fact]
    public void TestAddItemToCategory()
    {
        // Act
        var result = fixture.ItemService.AddItemToCategory(fixture.TestCategoryItem.Id, fixture.TestItem.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestItem.Id, result.Id);
        Assert.Equal(fixture.TestCategoryItem.Id, result.CategoryId);
    }

    [Fact]
    public void TestRemoveItemFromCategory()
    {
        // Act
        var result = fixture.ItemService.RemoveItemFromCategory(fixture.TestCategoryItem.Id, fixture.TestItem.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(fixture.TestItem.Id, result.Id);
        Assert.Null(result.CategoryId);
    }

    [Fact]
    public void TestAddItemToCategoryInvalidItem()
    {
        // Act
        var result = fixture.ItemService.AddItemToCategory(fixture.TestCategoryItem.Id, 2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TestRemoveItemFromCategoryInvalidItem()
    {
        // Act
        var result = fixture.ItemService.RemoveItemFromCategory(fixture.TestCategoryItem.Id, 2);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void TestRemoveItemFromCategoryInvalidCategoryAndItem()
    {
        // Act
        var result = fixture.ItemService.RemoveItemFromCategory(2, 2);

        // Assert
        Assert.Null(result);
    }
}