using Lootbox.View;

public interface IItemPool
{
    void CreateInitialItems(int count);
    void RecycleItem();
    IItemView GetItemAt(int index);
    int ItemCount { get; }
    float TotalHeight { get; }
}
