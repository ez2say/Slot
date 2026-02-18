using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Lootbox.Data;

namespace Lootbox.View
{
    public class ItemPool : IItemPool
    {
        private readonly List<IItemView> _items = new List<IItemView>();
        private RectTransform _container;
        private IItemRepository _itemRepository;
        private IFactory<IItemView> _itemViewFactory;
        private float _itemHeight;


        public void Initialize(RectTransform container, IItemRepository itemRepository,
                              IFactory<IItemView> itemViewFactory, float itemHeight)
        {
            _container = container;
            _itemRepository = itemRepository;
            _itemViewFactory = itemViewFactory;
            _itemHeight = itemHeight;
        }

        public int ItemCount => _items.Count;

        public float TotalHeight => _items.Count * _itemHeight;

        public void CreateInitialItems(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var itemView = _itemViewFactory.Create();
                var go = ((MonoBehaviour)itemView).gameObject;
                go.transform.SetParent(_container, false);
                var rt = ((MonoBehaviour)itemView).GetComponent<RectTransform>();

                rt.anchoredPosition = new Vector2(0, (count - 1 - i) * _itemHeight);

                itemView.SetItem(_itemRepository.GetRandomItem());
                _items.Add(itemView);
            }

            _container.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, TotalHeight);
            _container.anchoredPosition = new Vector2(0, 0);
        }

        public void RecycleItem()
        {
            var lastItem = _items[^1];
            var lastRt = ((MonoBehaviour)lastItem).GetComponent<RectTransform>();

            if (lastRt.anchoredPosition.y + _container.anchoredPosition.y > -_itemHeight)
                return;

            _items.RemoveAt(_items.Count - 1);

            var firstItem = _items[0];
            var firstRt = ((MonoBehaviour)firstItem).GetComponent<RectTransform>();

            lastRt.anchoredPosition = new Vector2(0, firstRt.anchoredPosition.y + _itemHeight);
            lastItem.SetItem(_itemRepository.GetRandomItem());

            _items.Insert(0, lastItem);
        }

        public IItemView GetItemAt(int index)
        {
            return _items[index];
        }
    }
}