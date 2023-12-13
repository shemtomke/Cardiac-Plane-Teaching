using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float sensX = 2;
    public float sensY = 2;

    public Transform orientation;

    float xRotation;
    float yRotation;
    private void Start()
    {
        LockCursor();
    }
    private void Update()
    {
        Movement();
        Rotation();
        ClampCameraPosition();
    }
    void Movement()
    {
        // Camera Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
    void Rotation()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    void ClampCameraPosition()
    {
        // Clamp camera position within specified boundaries
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -3, 3),
            Mathf.Clamp(transform.position.y, -3, 3),
            Mathf.Clamp(transform.position.z, -1, 5)
        );

        transform.position = clampedPosition;
    }
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
