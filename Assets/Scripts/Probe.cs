using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probe : MonoBehaviour
{
    public float currentXAxis, currentYAxis, currentZAxis;
    public float rotationSpeed = 5.0f;

    public bool clockWise = false; // if false then - anticlockwise (0 to 90) set x axis to 90 (greater than 0),
                           // otherwise, clock wise (90 to 0) set x axis to 0

    private void Update()
    {
        //RotateAntiClockWise();
        //RotateClockWise();
    }
    // Tilt - Up and Down (|) - Longest Diameter of the probe front, (-) Left or Right
    void TiltProbe()
    {
        if(clockWise)
        {
            // Up & Down

        }
        else
        {
            // Left or Right

        }
    }
    // Angulation - Left Or Right (|) - shortest diameter of the point (-) Up and Down
    void AngulateProbe()
    {
        if (clockWise)
        {
            // Left or Right

        }
        else
        {
            // Up & Down

        }
    }
    // Rotation - Rotate from | to -
    public void RotateAntiClockWise()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.eulerAngles;

        // Rotate around the x-axis
        float newRotationX = currentRotation.x - rotationSpeed * Time.deltaTime;

        // Ensure the rotation stays within the desired range
        if (newRotationX < -90)
        {
            newRotationX = -90;
            clockWise = false;
        }

        // Set the new rotation
        transform.eulerAngles = new Vector3(newRotationX, 90, 90);
    }
    public void RotateClockWise()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.eulerAngles;

        // Rotate around the x-axis
        float newRotationX = currentRotation.x + rotationSpeed * Time.deltaTime;

        // Ensure the rotation stays within the desired range
        if (newRotationX > 0)
        {
            newRotationX = 0;
            clockWise = true;
        }

        // Set the new rotation
        transform.eulerAngles = new Vector3(newRotationX, 90, 90);
    }
    public void RotateProbe() // Rotate the X axis clock wise or anti clockwise
    {
        
        //if (newRotationX == 90)
        //    clockWise = false;
        //else if(newRotationX == 0)
        //    clockWise = true;
    }
    void MoveUp()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    void MoveDown()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
    void MoveLeft()
    {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
    void MoveRight()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
}
