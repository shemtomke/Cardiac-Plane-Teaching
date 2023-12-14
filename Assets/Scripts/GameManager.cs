using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ChamberViews currentChamberView;

    public GameObject probeObject;
    public GameObject ribCage;
    public GameObject heart;
    public GameObject menu;
    public GameObject gameUI;

    public bool activateRib;
    public bool activateHeart;
    public bool isMenu;
    public bool isSelectChamber;

    //Adjust to the preferred positions for each chamber/probe
    public List<Vector3> probePositions;
    public List<Vector3> probeRotations;

    CameraMovement cameraMovement;
    private void Start()
    {
        cameraMovement = FindObjectOfType<CameraMovement>();

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

        //GoToMenu();
        AllowTweaking();
        gameUI.SetActive(isSelectChamber);
        menu.SetActive(isMenu);
    }
    // Position the Probe & Camera for each chamber selected
    public void SelectChamber(int selectedChamber)
    {
        switch (selectedChamber)
        {
            case 0:
                currentChamberView = ChamberViews.Apical;
                probeObject.transform.position = probePositions[0];
                probeObject.transform.rotation = Quaternion.Euler(probeRotations[0]);
                isSelectChamber = true;
                cameraMovement.lockCamera = true;
                break;
            case 1:
                currentChamberView = ChamberViews.ParasternalLongAxis;
                probeObject.transform.position = probePositions[1];
                probeObject.transform.rotation = Quaternion.Euler(probeRotations[1]);
                isSelectChamber = true;
                cameraMovement.lockCamera = true;
                break;
            case 2:
                currentChamberView = ChamberViews.ParasternalShortAxis;
                probeObject.transform.position = probePositions[2];
                probeObject.transform.rotation = Quaternion.Euler(probeRotations[2]);
                isSelectChamber = true;
                cameraMovement.lockCamera = true;
                break;
            case 3:
                currentChamberView = ChamberViews.Subcostal;
                probeObject.transform.position = probePositions[3];
                probeObject.transform.rotation = Quaternion.Euler(probeRotations[3]);
                isSelectChamber = true;
                cameraMovement.lockCamera = true;
                break;
            case 4:
                currentChamberView = ChamberViews.Suprasternal;
                probeObject.transform.position = probePositions[4];
                probeObject.transform.rotation = Quaternion.Euler(probeRotations[4]);
                isSelectChamber = true;
                cameraMovement.lockCamera = true;
                break;
            default:
                isSelectChamber = false;
                break;
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
    void ResetObjects()
    {
        activateHeart = true;
        activateRib = true;

        heart.SetActive(activateHeart);
        ribCage.SetActive(activateRib);
    }
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