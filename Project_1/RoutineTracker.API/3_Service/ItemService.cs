using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;
using RoutineTracker.API.Repository;

namespace RoutineTracker.API.Service;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public Item CreateItem(ItemInDTO newItem)
    {
        var item = newItem.ToItem();
        return _itemRepository.CreateItem(item);
    }

    public Item? GetItemById(int id)
    {
        return _itemRepository.GetItemById(id);
    }

    public Item? UpdateItemById(int id, ItemInDTO updatedItem)
    {
        var item = updatedItem.ToItem();
        return _itemRepository.UpdateItemById(id, item);
    }

    public Item? DeleteItemById(int id)
    {
        return _itemRepository.DeleteItemById(id);
    }

    public IEnumerable<Item> GetItemsByCategoryId(int categoryId)
    {
        return _itemRepository.GetItemsByCategoryId(categoryId);
    }

    public IEnumerable<Item> GetItemsByUserId(int userId)
    {
        return _itemRepository.GetItemsByUserId(userId);
    }

    public Item? AddItemToCategory(int itemId, int categoryId)
    {
        return _itemRepository.AddItemToCategory(itemId, categoryId);
    }

    public Item? RemoveItemFromCategory(int itemId, int categoryId)
    {
        return _itemRepository.RemoveItemFromCategory(itemId, categoryId);
    }
}