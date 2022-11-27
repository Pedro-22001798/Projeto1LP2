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
    [SerializeField] private Text coinsProduced;
    [SerializeField] private Text foodProduced;

    void Start()
    {
        tileInformationCanvas.SetActive(false);
    }

    public void ChangeTerrainInformation(TerrainType terrainType, Color terrainColor, List<Resource> terrainResources, int Gold, int Food)
    {
        tileInformationCanvas.SetActive(true);
        tileTypeText.text = "Tile Type = " + terrainType.ToString(); 
        tileColor.color = terrainColor;
        tileResourcesText.text = string.Empty;
        tileResourcesText.text = "Resouces =";

        int newGold = Gold;
        int newFood = Food;

        foreach (Resource r in terrainResources)
        {
            ResourceType _resourceType = r.typeOfResource;
            tileResourcesText.text += " " + _resourceType.ToString();
            newGold += r.gold;
            newFood += r.food;
        }
        coinsProduced.text = "Coins/Round = " + newGold.ToString();
        foodProduced.text = "Food/Round = " + newFood.ToString();
    }

    public void CloseWindow()
    {
        tileInformationCanvas.SetActive(false);
    }
}
