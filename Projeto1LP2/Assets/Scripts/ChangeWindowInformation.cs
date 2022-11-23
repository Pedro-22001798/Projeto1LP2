using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWindowInformation : MonoBehaviour
{
    [SerializeField] private GameObject tileInformationCanvas;
    [SerializeField] private Text tileTypeText;
    [SerializeField] private Text tileResourcesText;
    [SerializeField] private Image tileColor;

    void Start()
    {
        tileInformationCanvas.SetActive(false);
    }

    public void ChangeTerrainInformation(TerrainType terrainType, Color terrainColor, List<ResourceType> terrainResources)
    {
        tileInformationCanvas.SetActive(true);
        tileTypeText.text = "Tile Type = " + terrainType.ToString();
        tileColor.color = terrainColor;
        tileResourcesText.text = string.Empty;
        tileResourcesText.text = "Resouces =";
        foreach (ResourceType r in terrainResources)
        {
            tileResourcesText.text += " " + r.ToString();
        }
    }

    public void CloseWindow()
    {
        tileInformationCanvas.SetActive(false);
    }
}
