using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private float xRotation = 0;

    [SerializeField]
    private float xSensitivity = 1;
    [SerializeField]
    private float ySensitivity = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current == null || Time.timeScale!=1) return;
        Vector2 mouseInput = Mouse.current.delta.ReadValue();
        xRotation -= mouseInput.y * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.Rotate(0f, mouseInput.x * xSensitivity, 0);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
