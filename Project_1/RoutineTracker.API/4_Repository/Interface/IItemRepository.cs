using RoutineTracker.API.Model;

namespace RoutineTracker.API.Repository;

public interface IItemRepository
{
    Item CreateItem(Item newItem);
    Item? GetItemById(int id);
    Item? UpdateItemById(int id, Item updatedItem);
    Item? DeleteItemById(int id);
}