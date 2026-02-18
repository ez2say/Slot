using AxGrid;
using AxGrid.FSM;
using Lootbox.View;
using Lootbox.Data;

namespace Lootbox.States
{
    [State("Stopping")]
    public class StoppingState : FSMState
    {
        private readonly IWheelView _wheelView;

        public StoppingState(IWheelView wheelView)
        {
            _wheelView = wheelView;
        }

        [Enter]
        public void Enter()
        {
            Settings.Model.Set("StartButtonEnabled", false);
            Settings.Model.Set("StopButtonEnabled", false);
            _wheelView.StopSpin(OnSpinFinished);
            Settings.Invoke("OnSpinFinished");
        }

        private void OnSpinFinished(ItemDefinition winningItem)
        {
            Settings.Invoke("SpinFinished", winningItem);
            Settings.Invoke("OnSpinStopped");
            Parent.Change("Idle");
        }
    }
}