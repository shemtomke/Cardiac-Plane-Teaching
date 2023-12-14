using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Probe : MonoBehaviour
{
    public Slider rotationSlider;
    public Slider tiltSlider;
    public Slider angulateSlider;

    public Text axisText;

    private void Start()
    {

    }
    private void Update()
    {
        Axis();
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
    void Axis()
    {
        axisText.text = "X : " + transform.eulerAngles.x + "\nY : " + transform.eulerAngles.y + "\nZ : " + transform.eulerAngles.z;
    }
}
