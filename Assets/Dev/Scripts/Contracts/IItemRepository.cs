using System.Collections.Generic;

namespace Lootbox.Data
{
    public interface IItemRepository
    {
        ItemDefinition GetRandomItem();
        ItemDefinition GetItemById(string id);
        IReadOnlyList<ItemDefinition> GetAllItems();
    }
}