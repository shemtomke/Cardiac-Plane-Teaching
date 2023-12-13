using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probe : MonoBehaviour
{
    public float currentXAxis, currentYAxis, currentZAxis;
    public float rotationSpeed = 5.0f;

    public float maxTilt, minTilt;
    public float maxAngulation, minAngulation;

    public bool clockWise = false; // if false then - anticlockwise (0 to 90) set x axis to 90 (greater than 0),
                                   // otherwise, clock wise (90 to 0) set x axis to 0

    public Slider rotationSlider;
    private void Update()
    {
        //RotateAntiClockWise();
        //RotateClockWise();
    }
    // Tilt - Up and Down (|) - Longest Diameter of the probe front, (-) Left or Right
    #region Tilt
    public void TiltProbe()
    {
        if(clockWise)
        {
            // Up & Down
            // Get the current rotation
            Vector3 currentRotation = transform.eulerAngles;

            // Rotate around the x-axis
            float newTiltZ= currentRotation.z - rotationSpeed * Time.deltaTime;

            // Ensure the rotation stays within the desired range
            if (newTiltZ > maxTilt)
            {
                newTiltZ = maxTilt;
                clockWise = false;
            }

            // Set the new rotation
            transform.eulerAngles = new Vector3(0, 90, newTiltZ);
        }
        else
        {
            // Left or Right

        }
    }
    #endregion
    // Angulation - Left Or Right (|) - shortest diameter of the point (-) Up and Down
    #region Angulation
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
    #endregion
    // Rotation - Rotate from | to -
    #region Rotation
    public void RotateAntiClockWise()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.eulerAngles;

        // Ensure the rotation stays within the desired range
        if (currentRotation.x < -90)
        {
            clockWise = false;
        }

        // Set the new rotation
        transform.eulerAngles = new Vector3(rotationSlider.value, 90, 90);
    }
    public void RotateClockWise()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.eulerAngles;

        // Ensure the rotation stays within the desired range
        if (currentRotation.x > 0)
        {
            clockWise = true;
        }

        // Set the new rotation
        transform.eulerAngles = new Vector3(rotationSlider.value, 90, 90);
    }
    #endregion
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
