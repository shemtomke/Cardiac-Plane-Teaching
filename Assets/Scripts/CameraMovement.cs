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

    public bool lockCamera; // Allows access to the navigation for rotation, angulate and tilr

    float xRotation;
    float yRotation;

    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        lockCamera = true;
    }
    private void Update()
    {
        if(gameManager.isSelectChamber && lockCamera)
        {
            LockCursor();
            Movement();
            Rotation();
            ClampCameraPosition();
        }
        else
        {
            UnLockCursor();
        }
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
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void UnLockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
