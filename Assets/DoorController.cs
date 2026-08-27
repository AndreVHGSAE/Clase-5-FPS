using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameEvent.instance.onDoorTriggerEnter += OpenDoor;
        GameEvent.instance.onDoorTriggerExit += CloseDoor;
    }

    private void OnDisable()
    {
        GameEvent.instance.onDoorTriggerEnter -= OpenDoor;
    }

    private void OnDestroy()
    {
        GameEvent.instance.onDoorTriggerEnter -= OpenDoor;
    }

    // Update is called once per frame
    void OpenDoor()
    {
        //transform.Translate(new Vector3(0, 4, 0));
        transform.DOMoveY(6, 2);
    }

    void CloseDoor()
    {
        //transform.Translate(new Vector3(0, -4, 0));
        transform.DOMoveY(1.14f, 2);
    }
}
