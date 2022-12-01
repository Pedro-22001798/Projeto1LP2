using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClickInformation : MonoBehaviour
{
    private Tile tileSpecifications;
    private GameObject canvasManager;
    private GameObject mapManager;
    private ChangeWindowInformation changeWindowInformationScript;
    private NewMap mapManagerScript;
    private Color testColor;

    [SerializeField] private int row;
    [SerializeField] private int col;

    void Start()
    {
        canvasManager = GameObject.FindWithTag("CanvasManager");
        changeWindowInformationScript = canvasManager.GetComponent<ChangeWindowInformation>();
        mapManager = GameObject.FindWithTag("MapManager");
        mapManagerScript = mapManager.GetComponent<NewMap>();
        testColor = new Color(0f,1f,0f);
    }
    void OnMouseDown()
    {
        tileSpecifications = mapManagerScript.GetTile(row,col);
        changeWindowInformationScript.ChangeTerrainInformation(tileSpecifications.Terrain, testColor, tileSpecifications.Resources, tileSpecifications.Gold, tileSpecifications.Food); 
    }

}
