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
    public void AngulateAngle(float minAngle, float maxAngle)
    {
        angulateSlider.minValue = minAngle;
        angulateSlider.maxValue = maxAngle;
    }
}
