using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probe : MonoBehaviour
{
    public Slider rotationSlider;
    public Slider tiltSlider;
    public Slider angulateSlider;

    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {

    }
    public void UpdateRotation()
    {
        // Get the rotation values from the sliders
        float xRotation = rotationSlider.value;
        float yRotation = angulateSlider.value;
        float zRotation = tiltSlider.value;

        // Apply the rotations independently
        Quaternion newRotation = Quaternion.Euler(xRotation, yRotation, zRotation);

        // Apply the new rotation to the object
        transform.rotation = newRotation;
    }
    public void TiltAngle(float minAngle, float maxAngle)
    {
        tiltSlider.minValue = minAngle;
        tiltSlider.maxValue = maxAngle;
    }
    public void RotationAngle(float minAngle, float maxAngle)
    {
        rotationSlider.minValue = minAngle;
        rotationSlider.maxValue = maxAngle;
    }
}

// Rotation = 30 difference
