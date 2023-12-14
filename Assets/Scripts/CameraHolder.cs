using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    public Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.position;
    }
    public void ResetCam()
    {
        transform.position = new Vector3(0, 0, 0);
        Quaternion newRotation = Quaternion.Euler(0, 0, 0);
        transform.rotation = newRotation;
    }
}
