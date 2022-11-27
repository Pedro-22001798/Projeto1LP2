using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClickInformation : MonoBehaviour
{
    private Tile tileSpecifications;
    private GameObject canvasManager;
    private ChangeWindowInformation changeWindowInformationScript;
    private Color testColor;

    void Start()
    {
        canvasManager = GameObject.FindWithTag("CanvasManager");
        changeWindowInformationScript = canvasManager.GetComponent<ChangeWindowInformation>();
        testColor = new Color(0f,1f,0f);
    }
    void OnMouseDown()
    {
        tileSpecifications = GetComponent<Tile>();
        changeWindowInformationScript.ChangeTerrainInformation(tileSpecifications.Terrain, testColor, tileSpecifications.Resources, tileSpecifications.Gold, tileSpecifications.Food); 
    }

}
