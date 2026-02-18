using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using Lootbox.States;
using Lootbox.View;
using UnityEngine;
using Zenject;

namespace Lootbox.Core
{
    public class GameController : MonoBehaviourExt
    {
        private IWheelView _wheelView;
        private FSM _fsm;

        [Inject]
        public void Construct(IWheelView wheelView)
        {
            _wheelView = wheelView;
        }

        [OnStart]
        private void StartFSM()
        {
            _fsm = new FSM();
            _fsm.Add(new IdleState(_wheelView));
            _fsm.Add(new SpinningState(_wheelView));
            _fsm.Add(new StoppingState(_wheelView));

            Settings.Fsm = _fsm;
            _fsm.Start("Idle");
        }

        [OnUpdate]
        private void UpdateFSM()
        {
            _fsm?.Update(Time.deltaTime);
        }
    }
}