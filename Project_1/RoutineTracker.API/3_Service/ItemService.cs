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
}