using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFiller : MonoBehaviour
{
    [SerializeField] private GameObject testObject;
    private GameObject mapManager;
    private NewMap mapManagerScript;
    private Tile tileSpecifications;

    void Start()
    {
        mapManager = GameObject.FindWithTag("MapManager");
        mapManagerScript = mapManager.GetComponent<NewMap>();
    }

    public void FillMap(int rows, int cols)
    {
        for(int row = 0; row < rows; row++)
        {
            for(int col = 0; col < cols; col++)
            {
                GameObject newTile = Instantiate(testObject, new Vector3(2 * col, 2 * -row, 0), Quaternion.identity);
                TileClickInformation tileInformation = newTile.GetComponent<TileClickInformation>();
                tileInformation.DefineCoords(row,col);
                tileSpecifications = mapManagerScript.GetTile(row,col);
                SpriteRenderer tileRenderer = newTile.GetComponent<SpriteRenderer>();
                tileRenderer.color = tileSpecifications.Color;
            }
        }
    }
}