using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probe : MonoBehaviour
{
    public float currentXAxis, currentYAxis, currentZAxis;
    public float rotationSpeed = 5.0f;

    // X axis is 0 meaning when in long diameter or short diameter we do things normal else we alter and do it opposite
    bool isRotated = false;

    // Longer Diamater
    private void Update()
    {
        //RotateDown(); // Left (-Y)
        //RotateLeft(); // Up (-X axis)
        //RotateRight(); // Down (+X axis)
        //RotateUp(); // Right (+Y)
    }
    // Tilt - Up and Down (|) - Longest Diameter of the probe front
    void TiltProbe()
    {

    }
    // Rotation - Rotate from | to --
    public void RotateProbe() // Rotate the X axis clock wise or anti clockwise
    {
        if (currentXAxis < 270)
            transform.Rotate(new Vector3(270, 270, 270), rotationSpeed * Time.deltaTime);
        else if(currentXAxis >= 270)
            transform.Rotate(new Vector3(0, 270, 270), rotationSpeed * Time.deltaTime);
    }
    void RotateUp()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    void RotateDown()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
    void RotateLeft() // When 0 it goes to the right, when 270 goes down
    {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
    void RotateRight()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
    // Angulation - Left Or Right (|) - shortest diameter of the point


}
