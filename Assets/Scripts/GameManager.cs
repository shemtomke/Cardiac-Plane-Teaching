using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public GameObject topNavUI;
    public GameObject escObject;

    public GameObject orientationPanel;

    public GameObject chamberMarkingObj;

    public GameObject chamberDescriptionPanel;
    public Text chamberDescription;
    public Text chamberTitle;

    [Space(20)]
    public bool activateRib;
    public bool activateHeart;
    public bool isMenu;
    public bool isSelectChamber;

    [Space(10)]
    //Adjust to the preferred positions for each chamber/probe
    public List<Vector3> probePositions;
    public List<Vector3> probeRotations;
    public List<Vector3> chamberMarkings;

    [Space(10)]
    public List<Chamber> chambers;

    CameraMovement cameraMovement;
    CameraHolder cameraHolder;
    Probe probe;

    Tilt tilt;
    Angulate angulate;
    Rotation rotation;

    private void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();
        cameraHolder = FindObjectOfType<CameraHolder>();
        probe = FindObjectOfType<Probe>();
        tilt = FindObjectOfType<Tilt>();
        angulate = FindObjectOfType<Angulate>();
        rotation = FindObjectOfType<Rotation>();

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
            
            //  Angle Restriction
            probe.TiltAngle(chambers[selectedChamber].minTiltAngle, chambers[selectedChamber].maxtiltAngle);
            probe.RotationAngle(chambers[selectedChamber].minRotationAngle, chambers[selectedChamber].maxRotationAngle);
            probe.AngulateAngle(chambers[selectedChamber].minAngulateAngle, chambers[selectedChamber].maxAngulateAngle);

            probe.rotationSlider.value = probeRotations[selectedChamber].x;
            probe.angulateSlider.value = probeRotations[selectedChamber].y;
            probe.tiltSlider.value = probeRotations[selectedChamber].z;

            tilt.UpdateSlider();
            angulate.UpdateSlider();
            rotation.UpdateSlider();

            probeObject.transform.position = probePositions[selectedChamber];
            probeObject.transform.rotation = Quaternion.Euler(probeRotations[selectedChamber]);
            chamberMarkingObj.transform.position = chamberMarkings[selectedChamber];
            chamberTitle.text = chambers[selectedChamber].ChamberViews.ToString();
            chamberDescription.text = chambers[selectedChamber].chamberDescription;

            orientationPanel.SetActive(false);
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

        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the current scene again to reset it
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void AllowTweaking()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isSelectChamber)
        {
            cameraMovement.lockCamera = !cameraMovement.lockCamera;

            if(cameraMovement.lockCamera)
            {
                escObject.SetActive(true);
                topNavUI.SetActive(false);
            }
            else
            {
                escObject.SetActive(false);
                topNavUI.SetActive(true);
            }
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
    public string chamberDescription;
    public float maxtiltAngle, minTiltAngle;
    public float maxRotationAngle, minRotationAngle;
    public float maxAngulateAngle, minAngulateAngle;
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