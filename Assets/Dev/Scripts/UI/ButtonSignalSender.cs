using UnityEngine;
using UnityEngine.UI;
using AxGrid;
using AxGrid.Base;

namespace Lootbox.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonSignalSender : MonoBehaviourExt
    {
        [SerializeField] private string _signal;

        private Button _button;

        [OnAwake]
        private void Initialization()
        {
            _button = GetComponent<Button>();

            _button.onClick.AddListener(() => Settings.Invoke(_signal));
        }

        private void OnClick()
        {
            Debug.Log($"Button clicked, sending signal: {_signal}");
            Settings.Invoke(_signal);
        }
    }
}