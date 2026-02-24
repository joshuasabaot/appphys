using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Transform playerbody;
    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 100f;
    InputAction Look;
    float xRotation = 0f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        Look = InputSystem.actions.FindAction("Look");
    }

    private void Update()
    {
        var lookDirection = Look.ReadValue<Vector2>();
        var mouseX = lookDirection.x * Time.deltaTime * mouseSensitivityX;
        var mouseY = lookDirection.y * Time.deltaTime * mouseSensitivityY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerbody.Rotate(Vector3.up * mouseX);

    }
}
