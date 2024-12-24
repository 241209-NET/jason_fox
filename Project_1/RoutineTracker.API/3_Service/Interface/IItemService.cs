using RoutineTracker.API.DTO;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Service;

public interface IItemService
{
    Item CreateItem(ItemInDTO newItem);
    Item? GetItemById(int id);
    Item? UpdateItemById(int id, ItemInDTO updatedItem);
    Item? DeleteItemById(int id);
}