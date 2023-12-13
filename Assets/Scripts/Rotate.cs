using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isButtonHeld = false;

    Probe probe;
    private void Start()
    {
        probe = FindObjectOfType<Probe>();
    }
    private void Update()
    {
        if (isButtonHeld)
        {
            probe.RotateAntiClockWise();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isButtonHeld = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonHeld = false;
    }
}
