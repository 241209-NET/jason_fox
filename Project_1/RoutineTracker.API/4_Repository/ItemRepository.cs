using RoutineTracker.API.Data;
using RoutineTracker.API.Model;

namespace RoutineTracker.API.Repository;

public class ItemRepository : IItemRepository
{
    private readonly RoutineTrackerContext _routineTrackerContext;
    public ItemRepository(RoutineTrackerContext routineTrackerContext)
    {
        _routineTrackerContext = routineTrackerContext;
    }

    public Item CreateItem(Item newItem)
    {
        _routineTrackerContext.Items.Add(newItem);
        _routineTrackerContext.SaveChanges();
        return newItem;
    }

    public Item? GetItemById(int id)
    {
        return _routineTrackerContext.Items.Find(id);
    }

    public Item? UpdateItemById(int id, Item updatedItem)
    {
        var item = _routineTrackerContext.Items.Find(id);
        if (item == null) return null;
        item.Name = updatedItem.Name;
        item.Description = updatedItem.Description;
        item.CategoryId = updatedItem.CategoryId;
        item.NextDate = updatedItem.NextDate;
        item.LastDate = updatedItem.LastDate;
        item.Frequency = updatedItem.Frequency;
        if (item.Frequency is not null)
        {
            item.NextDate = item.LastDate!.Value.AddDays(item.Frequency.Value);
        }
        _routineTrackerContext.SaveChanges();
        return item;
    }

    public Item? DeleteItemById(int id)
    {
        var item = _routineTrackerContext.Items.Find(id);
        if (item == null) return null;
        _routineTrackerContext.Items.Remove(item);
        _routineTrackerContext.SaveChanges();
        return item;
    }


}