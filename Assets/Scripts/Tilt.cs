using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tilt : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Slider tiltSlider;

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
        currentSliderValue = tiltSlider.value;
        tiltSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    private void OnSliderValueChanged(float value)
    {
        float delta = value - currentSliderValue;

        // Rotate only if there's a significant change in the slider value
        if (Mathf.Abs(delta) > 0.01f)
        {
            RotateAround(probeObj.transform.right, delta);
        }

        currentSliderValue = value;
    }

    private void RotateAround(Vector3 axis, float delta)
    {
        float rotationAmount = rotationSpeed * delta;
        probeObj.transform.RotateAround(probeObj.transform.position, axis, rotationAmount);
    }
}
