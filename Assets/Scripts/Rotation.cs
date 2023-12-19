using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Slider rotationSlider;

    private float previousSliderValue = 0;

    float currentSliderValue;
    Probe probe;
    GameObject probeObj;
    void Start()
    {
        probe = FindObjectOfType<Probe>();
        probeObj = probe.gameObject;

        currentSliderValue = rotationSlider.value;

        // Subscribe to the OnValueChanged event of the slider
        rotationSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        if (value > currentSliderValue)
        {
            // Slider is increasing
            RotateAround(probeObj.transform.up);
        }
        else if (value < currentSliderValue)
        {
            RotateAround(-probeObj.transform.up);
        }

        // when it stops
        currentSliderValue = value;
        //probeObj.transform.eulerAngles = new Vector3(value, probeObj.transform.eulerAngles.y, probeObj.transform.eulerAngles.z);
    }

    //private void RotateAround(Vector3 axis)
    //{
    //    // Perform the rotation using transform.RotateAround
    //    probeObj.transform.RotateAround(probeObj.transform.position, axis, rotationSpeed * Time.deltaTime);
    //}
    private void RotateAround(Vector3 axis)
    {
        // Calculate the current rotation angle around the x-axis
        float currentRotationX = probeObj.transform.localRotation.eulerAngles.x;

        // Calculate the new rotation angle
        float newRotationX = currentRotationX + rotationSpeed * Time.deltaTime;

        // Clamp the rotation angle within the specified range
        newRotationX = Mathf.Clamp(newRotationX, 0, 90);

        // Create a new local rotation quaternion with the updated angle
        Quaternion newRotation = Quaternion.Euler(newRotationX, 0f, 0f);

        // Apply the rotation using localRotation
        probeObj.transform.localRotation = newRotation;
    }
}
