using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AxGrid.Base;
using Lootbox.Data;
using Zenject;

namespace Lootbox.View
{
    public class WheelView : MonoBehaviourExt, IWheelView
    {

        [Header("WheelSettings")]
        [SerializeField] private float _itemHeight = 200f;
        [SerializeField] private int _visibleItemsCount = 3;
        [SerializeField] private float _spinSpeed = 500f;
        [SerializeField] private float _accelerationDuration = 1f;
        [SerializeField] private float _decelerationDuration = 1.5f;

        private IItemRepository _itemRepository;
        private IFactory<IItemView> _itemViewFactory;
        private IItemPool _itemPool;
        private IRotationController _rotation;
        private IAlignmentCalculator _calculator;

        private RectTransform _container;
        private Action<ItemDefinition> _stopCallback;

        [Inject]
        public void Construct(
            IItemRepository itemRepository,
            IFactory<IItemView> itemViewFactory,
            IItemPool itemPool,
            IRotationController rotationController,
            IAlignmentCalculator calculator)
        {
            _itemRepository = itemRepository;
            _itemViewFactory = itemViewFactory;
            _itemPool = itemPool;
            _rotation = rotationController;
            _calculator = calculator;
        }

        [OnAwake]
        private void Initialization()
        {
            _container = transform as RectTransform;
        }

        [OnStart]
        private void Play()
        {
            if (_itemPool is ItemPool pool)
            {
                pool.Initialize(_container, _itemRepository, _itemViewFactory, _itemHeight);
            }

            _itemPool.CreateInitialItems(_visibleItemsCount + 4);
            _container.anchoredPosition = new Vector2(0, -_itemHeight * 2);
        }

        [OnUpdate]
        private void UpdateSpin()
        {
            if (!_rotation.IsSpinning && _rotation.CurrentSpeed == 0)
                return;

            var pos = _container.anchoredPosition;
            pos.y -= _rotation.CurrentSpeed * Time.deltaTime;
            _container.anchoredPosition = pos;

            _itemPool.RecycleItem();
        }

        public void StartSpin()
        {
            _rotation.StartSpin(_spinSpeed, _accelerationDuration);
        }

        public void StopSpin(Action<ItemDefinition> onFinished)
        {
            _stopCallback = onFinished;
            _rotation.StopSpin(_decelerationDuration, AlignToCenter);
        }

        private void AlignToCenter()
        {
            var currentY = _container.anchoredPosition.y;
            var targetY = _calculator.CalculateTargetY(currentY, _itemHeight);

            _container.DOAnchorPosY(targetY, 0.3f)
                .SetEase(Ease.OutBack)
                .OnComplete(OnAlignmentComplete);
        }

        private void OnAlignmentComplete()
        {
            var centerIndex = _calculator.CalculateCenterIndex(
                _container.anchoredPosition.y,
                _container.rect.height,
                _itemHeight,
                _itemPool.ItemCount
            );

            var centerItem = _itemPool.GetItemAt(centerIndex);
            _stopCallback?.Invoke(centerItem.CurrentItem);
        }
    }
}