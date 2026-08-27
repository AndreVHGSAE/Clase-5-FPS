using System.Runtime.CompilerServices;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvent.instance.OpenTriggerDoor();
    }
    private void OnTriggerExit(Collider other)
    {
        GameEvent.instance.ExitTriggerDoor();
    }
}
