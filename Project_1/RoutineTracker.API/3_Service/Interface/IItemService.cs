using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Service;

public interface IItemService
{
    Item CreateItem(ItemInDTO newItem);
    Item? GetItemById(int id);
    Item? UpdateItemById(int id, ItemInDTO updatedItem);
    Item? DeleteItemById(int id);
    IEnumerable<Item> GetItemsByCategoryId(int categoryId);
    IEnumerable<Item> GetItemsByUserId(int userId);
    Item? AddItemToCategory(int itemId, int categoryId);
    Item? RemoveItemFromCategory(int itemId, int categoryId);
}