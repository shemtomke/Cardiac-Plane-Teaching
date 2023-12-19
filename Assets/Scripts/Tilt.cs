using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tilt : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Slider tiltSlider;

    private float previousSliderValue = 0;

    float currentSliderValue;
    Probe probe;
    GameObject probeObj;

    void Start()
    {
        probe = FindObjectOfType<Probe>();
        probeObj = probe.gameObject;

        currentSliderValue = tiltSlider.value;

        // Subscribe to the OnValueChanged event of the slider
        tiltSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    private void OnSliderValueChanged(float value)
    {
        if (value > currentSliderValue)
        {
            // Slider is increasing
            TiltAround(probeObj.transform.right);
        }
        else if (value < currentSliderValue)
        {
            TiltAround(-probeObj.transform.right);
        }

        // when it stops
        currentSliderValue = value;
    }
    private void TiltAround(Vector3 axis)
    {
        // Perform the rotation using transform.RotateAround
        probeObj.transform.RotateAround(probeObj.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
