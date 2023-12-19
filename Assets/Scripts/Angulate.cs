using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angulate : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Slider angulateSlider;

    private float previousSliderValue = 0;

    float currentSliderValue;
    Probe probe;
    GameObject probeObj;

    void Start()
    {
        probe = FindObjectOfType<Probe>();
        probeObj = probe.gameObject;

        currentSliderValue = angulateSlider.value;

        // Subscribe to the OnValueChanged event of the slider
        angulateSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    private void OnSliderValueChanged(float value)
    {
        if (value > currentSliderValue)
        {
            // Slider is increasing
            AngulateAround(probeObj.transform.forward);
        }
        else if (value < currentSliderValue)
        {
            AngulateAround(-probeObj.transform.forward);
        }

        // when it stops
        currentSliderValue = value;
    }
    private void AngulateAround(Vector3 axis)
    {
        // Perform the rotation using transform.RotateAround
        probeObj.transform.RotateAround(probeObj.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
