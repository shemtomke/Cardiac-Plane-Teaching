using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probe : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    private void Update()
    {
        RotateDown(); // Left (-Y)
        //RotateLeft(); // Up (-X axis)
        //RotateRight(); // Down (+X axis)
        //RotateUp(); // Right (+Y)
    }
    // Tilt - inclination or slanting.
    void TiltProbe()
    {

    }
    // Rotation - circular movement around an axis.
    void RotateUp()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    void RotateDown()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
    }
    void RotateLeft()
    {
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime);
    }
    void RotateRight()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
    }
    // Angulation - measuring or describing angles between objects or segments.

}
