using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField]
    private TriggerController triggerController;

    public float OriginalPosition;

    void Start()
    {
        /*GameEvent.instance.onDoorTriggerEnter += OpenDoor;
        GameEvent.instance.onDoorTriggerExit += CloseDoor;*/

        triggerController.onTriggerEnterEvent += OpenDoor;
        triggerController.onTriggerExitEvent += CloseDoor;

        OriginalPosition = transform.position.y;
    }

    private void OnDisable()
    {
        triggerController.onTriggerEnterEvent -= OpenDoor;
        triggerController.onTriggerExitEvent -= CloseDoor;
    }

    private void OnDestroy()
    {
        triggerController.onTriggerEnterEvent -= OpenDoor;
        triggerController.onTriggerExitEvent -= CloseDoor;
    }

    // Update is called once per frame
    void OpenDoor()
    {
        //transform.Translate(new Vector3(0, 4, 0));
        transform.DOLocalMoveY(OriginalPosition + 4, 2);
    }

    void CloseDoor()
    {
        //transform.Translate(new Vector3(0, -4, 0));
        transform.DOLocalMoveY(OriginalPosition, 2);
    }
}
