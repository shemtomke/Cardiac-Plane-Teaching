using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Toggle clockToggle;
    public ChamberViews currentChamberView;
    public int selectedChamberView;

    [Space(20)]
    public GameObject probeObject;
    public GameObject ribCage;
    public GameObject heart;
    public GameObject clock;
    public GameObject menu;
    public GameObject gameUI;

    [Space(20)]
    public bool activateRib;
    public bool activateHeart;
    public bool isMenu;
    public bool isSelectChamber;

    [Space(10)]
    //Adjust to the preferred positions for each chamber/probe
    public List<Vector3> probePositions;
    public List<Vector3> probeRotations;

    [Space(10)]
    public List<Chamber> chambers;

    CameraMovement cameraMovement;
    CameraHolder cameraHolder;
    Probe probe;
    private void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
        cameraHolder = FindObjectOfType<CameraHolder>();
        probe = FindObjectOfType<Probe>();

        currentChamberView = ChamberViews.Apical;

        activateHeart = true;
        activateRib = true;
        isSelectChamber = false;
        isMenu = true;
    }
    private void Update()
    {
        RibCage();
        Heart();

        if (isSelectChamber)
        {
            isMenu = false;
        }

        AllowTweaking();
        DefaultCamera();
        gameUI.SetActive(isSelectChamber);
        menu.SetActive(isMenu);

        clock.SetActive(clockToggle.isOn);
    }
    // Position the Probe & Camera for each chamber selected
    public void SelectChamber(int selectedChamber)
    {
        if (selectedChamber >= 0 && selectedChamber < probePositions.Count)
        {
            currentChamberView = (ChamberViews)selectedChamber;
            selectedChamberView = selectedChamber;
            probeObject.transform.position = probePositions[selectedChamber];
            probeObject.transform.rotation = Quaternion.Euler(probeRotations[selectedChamber]);

            Debug.Log(probeRotations[selectedChamber]);
            Debug.Log(probeObject.transform.rotation.eulerAngles);

            probe.rotationSlider.value = probeRotations[selectedChamber].x;
            probe.angulateSlider.value = probeRotations[selectedChamber].y;
            probe.tiltSlider.value = probeRotations[selectedChamber].z;

            //  Angle Restriction
            probe.TiltAngle(chambers[selectedChamber].minTiltAngle, chambers[selectedChamber].maxtiltAngle);
            probe.RotationAngle(chambers[selectedChamber].minRotationAngle, chambers[selectedChamber].maxRotationAngle);

            isSelectChamber = true;
            cameraMovement.lockCamera = true;
        }
        else
        {
            isSelectChamber = false;
        }
    }
    // Enable & Disable Specific Game Objects
    public void RibCage()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            activateRib = !activateRib; // Toggle the state
            ribCage.SetActive(activateRib);
        }
    }
    public void Heart()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            activateHeart = !activateHeart; // Toggle the state
            heart.SetActive(activateHeart);
        }
    }
    public void GoToMenu()
    {
        isMenu = !isMenu;
        isSelectChamber = false;
        ResetObjects();
    }
    public void AllowTweaking()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isSelectChamber)
        {
            cameraMovement.lockCamera = !cameraMovement.lockCamera;
        }
    }
    void DefaultCamera()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            cameraMovement.ResetCam();
            cameraHolder.ResetCam();
        }
    }
    void ResetObjects()
    {
        activateHeart = true;
        activateRib = true;

        heart.SetActive(activateHeart);
        ribCage.SetActive(activateRib);

        cameraMovement.ResetCam();
        cameraHolder.ResetCam();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
[System.Serializable]
public class Chamber
{
    public ChamberViews ChamberViews;
    public float maxtiltAngle, minTiltAngle;
    public float maxRotationAngle, minRotationAngle;
}
[Serializable]
public enum ChamberViews
{
    Apical,
    ParasternalLongAxis,
    ParasternalShortAxis,
    Subcostal,
    Suprasternal
}