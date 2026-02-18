using Lootbox.Data;

namespace Lootbox.View
{
    public interface IItemView
    {
        ItemDefinition CurrentItem { get; }
        void SetItem(ItemDefinition item);
        void Clear();
    }
}