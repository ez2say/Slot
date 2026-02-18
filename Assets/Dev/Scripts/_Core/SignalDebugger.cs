using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

public class SignalDebugger : MonoBehaviourExtBind
{
    [Bind("OnStartClick")]
    private void OnStart() => Debug.Log("Signal OnStartClick received");

    [Bind("OnStopClick")]
    private void OnStop() => Debug.Log("Signal OnStopClick received");
}