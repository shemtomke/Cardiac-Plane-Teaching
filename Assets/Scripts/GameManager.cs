using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ChamberViews currentChamberView;

    public GameObject probeObject;

    //Adjust to the preferred positions for each chamber/probe
    public List<Vector3> probePositions;
    public List<Vector3> probeRotations;

    private void Start()
    {
        currentChamberView = ChamberViews.Apical;
    }
    // Position the Probe & Camera for each chamber selected
    public void SelectChamber(int selectedChamber)
    {
        switch (selectedChamber)
        {
            case 0:
                currentChamberView = ChamberViews.Apical;
                probeObject.transform.position = probePositions[0];
                probeObject.transform.position = probeRotations[0];
                break;
            case 1:
                currentChamberView = ChamberViews.ParasternalLongAxis;
                probeObject.transform.position = probePositions[1];
                probeObject.transform.position = probeRotations[1];
                break;
            case 2:
                currentChamberView = ChamberViews.ParasternalShortAxis;
                probeObject.transform.position = probePositions[2];
                probeObject.transform.position = probeRotations[2];
                break;
            case 3:
                currentChamberView = ChamberViews.Subcostal;
                probeObject.transform.position = probePositions[3];
                probeObject.transform.position = probeRotations[3];
                break;
            case 4:
                currentChamberView = ChamberViews.Suprasternal;
                probeObject.transform.position = probePositions[4];
                probeObject.transform.position = probeRotations[4];
                break;
            default:
                break;
        }
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