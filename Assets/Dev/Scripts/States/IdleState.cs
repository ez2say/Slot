using AxGrid;
using AxGrid.FSM;
using AxGrid.Model;
using Lootbox.View;
using UnityEngine;

namespace Lootbox.States
{
    [State("Idle")]
    public class IdleState : FSMState
    {
        private readonly IWheelView _wheelView;

        public IdleState(IWheelView wheelView)
        {
            _wheelView = wheelView;
        }

        [Enter]
        public void Enter()
        {
            Settings.Model.Set("StartButtonEnabled", true);
            Settings.Model.Set("StopButtonEnabled", false);
        }

        [Bind("OnStartClick")]
        private void OnStartClick()
        {
            Debug.Log($"Parent FSM is null? {Parent == null}");
            if (Parent != null)
            {
                Parent.Change("Spinning");
                Debug.Log("Change called");
            }
            else
            {
                Debug.LogError("Parent is null!");
            }
        }
    }
}