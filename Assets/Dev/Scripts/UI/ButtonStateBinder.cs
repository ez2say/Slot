using UnityEngine;
using UnityEngine.UI;
using AxGrid.Base;
using AxGrid.Model;

namespace Lootbox.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonStateBinder : MonoBehaviourExtBind
    {
        [SerializeField] private string _field;

        private Button _button;

        [OnAwake]
        private void Initialization()
        {
            _button = GetComponent<Button>();
        }

        [Bind("On{_field}Changed")]
        private void OnStateChanged(bool enabled)
        {
            _button.interactable = enabled;
        }
    }
}