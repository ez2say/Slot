using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using Lootbox.View;
using UnityEngine;

namespace Lootbox.States
{
    [State("Spinning")]
    public class SpinningState : FSMState
    {
        private readonly IWheelView _wheelView;

        public SpinningState(IWheelView wheelView)
        {
            _wheelView = wheelView;
            Debug.Log("SpinningState constructed");
        }

        [Enter]
        public void Enter()
        {
            Settings.Model.Set("StartButtonEnabled", false);
            Settings.Model.Set("StopButtonEnabled", false);
            _wheelView.StartSpin();
            Settings.Invoke("OnSpinStarted");
        }

        [One(3f)]
        private void EnableStopButton()
        {
            Settings.Model.Set("StopButtonEnabled", true);
        }

        [Bind("OnStopClick")]
        private void OnStopClick()
        {
            if (Settings.Model.GetBool("StopButtonEnabled"))
                Parent.Change("Stopping");
        }
    }
}