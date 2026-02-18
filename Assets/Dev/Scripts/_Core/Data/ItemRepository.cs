using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lootbox.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<ItemDefinition> _items;
        private readonly int _totalWeight;

        public ItemRepository(List<ItemDefinition> items)
        {
            _items = items;
            _totalWeight = items.Sum(item => item.Weight);
        }

        public ItemDefinition GetRandomItem()
        {
            if (_items.Count == 0) return null;
            int random = Random.Range(0, _totalWeight);
            int current = 0;
            foreach (var item in _items)
            {
                current += item.Weight;
                if (random < current)
                    return item;
            }
            return _items[0];
        }

        public ItemDefinition GetItemById(string id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public IReadOnlyList<ItemDefinition> GetAllItems() => _items;
    }
}