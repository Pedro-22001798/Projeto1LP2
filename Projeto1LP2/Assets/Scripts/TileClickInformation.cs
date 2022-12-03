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

    private int row;
    private int col;

    void Start()
    {
        canvasManager = GameObject.FindWithTag("CanvasManager");
        changeWindowInformationScript = canvasManager.GetComponent<ChangeWindowInformation>();
        mapManager = GameObject.FindWithTag("MapManager");
        mapManagerScript = mapManager.GetComponent<NewMap>();
    }

    public void DefineCoords(int newRow, int newCol)
    {
        row = newRow;
        col = newCol;
    }

    void OnMouseDown()
    {
        tileSpecifications = mapManagerScript.GetTile(row,col);
        changeWindowInformationScript.ChangeTerrainInformation(tileSpecifications.Terrain, tileSpecifications.Color, tileSpecifications.Resources, tileSpecifications.Gold, tileSpecifications.Food); 
    }

}
