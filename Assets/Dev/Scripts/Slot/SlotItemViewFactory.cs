using Zenject;
using Lootbox.View;

public class SlotItemViewFactory : IFactory<IItemView>
{
    private readonly DiContainer _container;
    private readonly SlotItemView _prefab;

    public SlotItemViewFactory(DiContainer container, SlotItemView prefab)
    {
        _container = container;
        _prefab = prefab;
    }

    public IItemView Create()
    {
        return _container.InstantiatePrefabForComponent<SlotItemView>(_prefab);
    }
}