using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Angulate : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Slider angulateSlider;

    float currentSliderValue;
    Probe probe;
    GameObject probeObj;

    void Start()
    {
        probe = FindObjectOfType<Probe>();
        probeObj = probe.gameObject;
    }
    public void UpdateSlider()
    {
        currentSliderValue = angulateSlider.value;
        angulateSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    private void OnSliderValueChanged(float value)
    {
        float delta = value - currentSliderValue;

        // Rotate only if there's a significant change in the slider value
        if (Mathf.Abs(delta) > 0.01f)
        {
            RotateAround(probeObj.transform.forward, delta);
        }

        currentSliderValue = value;
    }
    private void RotateAround(Vector3 axis, float delta)
    {
        float rotationAmount = rotationSpeed * delta;
        probeObj.transform.RotateAround(probeObj.transform.position, axis, rotationAmount);
    }
}
