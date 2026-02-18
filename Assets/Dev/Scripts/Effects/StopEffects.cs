using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class StopEffects : MonoBehaviourExtBind
{
    [Bind("OnSpinStopped")]
    private void StartEffect()
    {
        gameObject.SetActive(true);
        GetComponent<ParticleSystem>()?.Play();
    }

}