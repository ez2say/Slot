using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Lootbox.Data;
using Lootbox.View;
using Lootbox.Core;

namespace Lootbox.Installers
{
    public class LootboxInstaller : MonoInstaller
    {
        [SerializeField] private List<ItemDefinition> _itemDefinitions;
        [SerializeField] private WheelView _wheelViewPrefab;
        [SerializeField] private Transform _wheelViewParent;
        [SerializeField] private SlotItemView _slotItemViewPrefab;

        public override void InstallBindings()
        {
            BindItemRepository();
            BindWheelView();
            BindItemViewFactory();
            BindGameController();
            BindWheelComponents();
        }

        private void BindItemRepository()
        {
            Container.Bind<IItemRepository>()
                .To<ItemRepository>()
                .AsSingle()
                .WithArguments(_itemDefinitions);
        }

        private void BindWheelView()
        {
            Container.Bind<IWheelView>()
                .To<WheelView>()
                .FromComponentInNewPrefab(_wheelViewPrefab)
                .UnderTransform(_wheelViewParent)
                .AsSingle();
        }

        private void BindItemViewFactory()
        {
            Container.Bind<IFactory<IItemView>>()
                .To<SlotItemViewFactory>()
                .AsSingle()
                .WithArguments(_slotItemViewPrefab);
        }

        private void BindWheelComponents()
        {
            Container.Bind<IItemPool>().To<ItemPool>().AsTransient();
            Container.Bind<IRotationController>().To<RotationController>().AsTransient();
            Container.Bind<IAlignmentCalculator>().To<AlignmentCalculator>().AsTransient();
        }

        private void BindGameController()
        {
            Container.Bind<GameController>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}