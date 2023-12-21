using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float sensX = 2;
    public float sensY = 2;

    public Transform orientation;

    public bool lockCamera; // Allows access to the navigation for rotation, angulate and tilr
    public Toggle freeMode;
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
    private void LateUpdate()
    {
        
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
        if(freeMode.isOn)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;

            // Clamp the xRotation to a desired range
            xRotation = Mathf.Clamp(xRotation, -45, 45);
            //yRotation = Mathf.Clamp(yRotation, -180, 180);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
    void ClampCameraPosition()
    {
        // Clamp camera position within specified boundaries
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(transform.position.x, -2, 2),
            Mathf.Clamp(transform.position.y, -1, 1),
            Mathf.Clamp(transform.position.z, 0, 5)
        );

        transform.position = clampedPosition;
    }
    public void LeftSideView()
    {
        transform.position = new Vector3(-2, 0, 2.5f);
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }
    public void RightSideView()
    {
        transform.position = new Vector3(2, 0, 2.5f);
        transform.rotation = Quaternion.Euler(0, -90, 0);
    }
    public void FrontSideView()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void BackSideView()
    {
        transform.position = new Vector3(0, 0, 5);
        transform.rotation = Quaternion.Euler(0, 180, 0);
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
    public void ResetCam()
    {
        transform.position = new Vector3(0, 0, 0);
        Quaternion newRotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = newRotation;
    }
}
