using System;
using Lootbox.Data;

namespace Lootbox.View
{
    public interface IWheelView
    {
        void StartSpin();
        void StopSpin(Action<ItemDefinition> onFinished);
    }
}