using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent instance;

    public event Action onDoorTriggerEnter;
    public event Action onDoorTriggerExit;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void OpenTriggerDoor()
    {
        onDoorTriggerEnter();
    }

    public void ExitTriggerDoor()
    {
        onDoorTriggerExit();
    }
}
