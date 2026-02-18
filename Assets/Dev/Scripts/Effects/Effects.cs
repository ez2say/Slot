using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class Effects : MonoBehaviourExtBind
{
    [Bind("OnSpinStarted")]
    private void StartEffect()
    {
        gameObject.SetActive(true);
        GetComponent<ParticleSystem>()?.Play();
    }

    [Bind("OnSpinFinished")]
    private void StopEffect()
    {
        gameObject.SetActive(false);
        GetComponent<ParticleSystem>()?.Stop();
    }
}