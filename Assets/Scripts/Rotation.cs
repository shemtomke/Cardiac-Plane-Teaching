using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Slider rotationSlider;

    private float previousSliderValue = 0;

    Probe probe;
    GameObject probeObj;
    void Start()
    {
        probe = FindObjectOfType<Probe>();
        probeObj = probe.gameObject;

        // Subscribe to the OnValueChanged event of the slider
        rotationSlider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    private void HandleSliderValueChanged(float sliderValue)
    {
        probeObj.transform.eulerAngles = new Vector3(sliderValue, probeObj.transform.eulerAngles.y, probeObj.transform.eulerAngles.z);
        RotateAround(probeObj.transform.up);
    }

    private void RotateAround(Vector3 axis)
    {
        // Perform the rotation using transform.RotateAround
        probeObj.transform.RotateAround(probeObj.transform.position, axis, rotationSpeed * Time.deltaTime);
    }
}
