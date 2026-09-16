using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggerController : MonoBehaviour
{

    public event Action onTriggerEnterEvent, onTriggerExitEvent;

    private void OnTriggerEnter(Collider other)
    {
        //GameEvent.instance.OpenTriggerDoor();
        onTriggerEnterEvent.Invoke();

    }
    private void OnTriggerExit(Collider other)
    {
        //GameEvent.instance.ExitTriggerDoor();
        onTriggerExitEvent.Invoke();

    }
}