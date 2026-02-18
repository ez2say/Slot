using UnityEngine;
using UnityEngine.UI;
using AxGrid.Base;
using Lootbox.Data;
using Zenject;

namespace Lootbox.View
{
    [RequireComponent(typeof(RectTransform), typeof(Image))]
    public class SlotItemView : MonoBehaviourExt, IItemView
    {

        private Image _image;
        private RectTransform _rectTransform;
        private ItemDefinition _currentItem;
        public ItemDefinition CurrentItem => _currentItem;
        public RectTransform RectTransform =>
            _rectTransform ??= GetComponent<RectTransform>();

        [OnAwake]
        private void Initialize()
        {
            _image = GetComponent<Image>();
        }

        public void SetItem(ItemDefinition item)
        {
            _currentItem = item;
            _image.sprite = item.Icon;
            _image.color = item.GlowColor;
        }

        public void Clear()
        {
            _image.sprite = null;
        }

    }
}