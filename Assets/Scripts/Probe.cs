using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probe : MonoBehaviour
{
    public Slider rotationSlider;
    public Slider tiltSlider;
    public Slider angulateSlider;

    public Text rotationText;
    public Text tiltText;
    public Text angulateText;

    GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        rotationText.text = "" + rotationSlider.value;
        tiltText.text = "" + tiltSlider.value;
        angulateText.text = "" + angulateSlider.value;
    }
    public void UpdateRotation() //Called By the Sliders
    {
        // Get the rotation values from the sliders
        float xRotation = rotationSlider.value;
        float yRotation = angulateSlider.value;
        float zRotation = tiltSlider.value;

        // Convert Euler angles to quaternion
        Quaternion xQuaternion = Quaternion.Euler(xRotation, 0, 0);
        Quaternion yQuaternion = Quaternion.Euler(0, yRotation, 0);
        Quaternion zQuaternion = Quaternion.Euler(0, 0, zRotation);

        // Combine the quaternions to represent the new rotation
        Quaternion newRotation = xQuaternion * yQuaternion * zQuaternion;

        // Apply the new rotation to the object
        transform.localRotation = newRotation;
    }
    public void TiltAngle(float minAngle, float maxAngle)
    {
        tiltSlider.minValue -= minAngle;
        tiltSlider.maxValue += maxAngle;
    }
    public void RotationAngle(float minAngle, float maxAngle)
    {
        rotationSlider.minValue = minAngle;
        rotationSlider.maxValue = maxAngle;
    }
}
