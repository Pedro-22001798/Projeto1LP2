using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFiller : MonoBehaviour
{
    [SerializeField] private GameObject testObject;
    private GameObject mapManager;
    private NewMap mapManagerScript;
    private Tile tileSpecifications;
    [SerializeField] private GameObject[] availableResources;
    List<Resource> tileResources;

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
                GameObject newTile = Instantiate(testObject, new Vector3(col, -row, 0), Quaternion.identity);
                TileClickInformation tileInformation = newTile.GetComponent<TileClickInformation>();
                tileInformation.DefineCoords(row,col);
                tileSpecifications = mapManagerScript.GetTile(row,col);
                SpriteRenderer tileRenderer = newTile.GetComponent<SpriteRenderer>();
                tileRenderer.color = tileSpecifications.Color;
                tileResources = tileSpecifications.Resources;
                for(int i = 0; i < tileResources.Count; i++)
                {
                    switch(tileResources[i].typeOfResource)
                    {
                        case ResourceType.Plants:
                            Instantiate(availableResources[0], newTile.transform.GetChild(i).transform.position, Quaternion.identity, newTile.transform.GetChild(i));
                            break;
                        case ResourceType.Animals:
                            Instantiate(availableResources[1], newTile.transform.GetChild(i).transform.position, Quaternion.identity, newTile.transform.GetChild(i));
                            break;
                        case ResourceType.Metals:
                            Instantiate(availableResources[2], newTile.transform.GetChild(i).transform.position, Quaternion.identity, newTile.transform.GetChild(i));
                            break;
                        case ResourceType.FossilFuel:
                            Instantiate(availableResources[3], newTile.transform.GetChild(i).transform.position, Quaternion.identity, newTile.transform.GetChild(i));
                            break;
                        case ResourceType.Luxury:
                            Instantiate(availableResources[4], newTile.transform.GetChild(i).transform.position, Quaternion.identity, newTile.transform.GetChild(i));
                            break;
                        case ResourceType.Pollution:
                            Instantiate(availableResources[5], newTile.transform.GetChild(i).transform.position, Quaternion.identity, newTile.transform.GetChild(i));
                            break;
                    }
                }
            }
        }
    }
}