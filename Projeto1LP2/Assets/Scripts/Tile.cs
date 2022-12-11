using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private static readonly Dictionary<string, TerrainType> terrainDict = new Dictionary<string, TerrainType>()
    {
        {"desert", TerrainType.Desert},
        {"plains", TerrainType.Plains},
        {"hills", TerrainType.Hills},
        {"mountain", TerrainType.Mountain},
        {"water", TerrainType.Water}
    };
    
    private List<Resource> terrainResources = new List<Resource>();

    ////////////
    // VARIABLES
    ////////////
    private TerrainType terrainType;
    private int defaultGoldValue;
    private int defaultFoodValue;
    private Color terrainColor;

    ////////////
    // METHODS
    ////////////
    public TerrainType Terrain {get => terrainType; }
    public Color Color {get => terrainColor; }
    public int Gold {get => defaultGoldValue; }
    public int Food {get => defaultFoodValue; }

    public List<Resource> Resources
    {
        get
        {
            List<Resource> tempResources = new List<Resource>();

            foreach (Resource r in terrainResources)
                tempResources.Add(r);
            
            return tempResources;
        }
    }

    public Tile(string terrain, List<Resource> resources)
    {
        if(terrainDict.ContainsKey(terrain))
        {
            terrainDict.TryGetValue(terrain, out terrainType);
            DefineBaseValues();
            terrainResources = new List<Resource>();
            foreach(Resource r in resources)
            {
                terrainResources.Add(r);
            }
        }
        else
        {
            Debug.Log("erro");
        }
    }

    private void DefineBaseValues()
    {
        switch (Terrain)
        {
            case TerrainType.Desert:
                defaultGoldValue = 0;
                defaultFoodValue = 0;
                terrainColor = new Color32(217,137,43,255);
                break;
            
            case TerrainType.Plains:
                defaultGoldValue = 0;
                defaultFoodValue = 2;
                terrainColor = new Color32(165,177,15,255);
                break;
            
            case TerrainType.Hills:
                defaultGoldValue = 1;
                defaultFoodValue = 1;
                terrainColor = new Color32(24,71,35,255);
                break;
            
            case TerrainType.Mountain:
                defaultGoldValue = 1;
                defaultFoodValue = 0;
                terrainColor = new Color32(64,61,56,255);
                break;

            case TerrainType.Water:
                defaultGoldValue = 0;
                defaultFoodValue = 1;
                terrainColor = new Color32(20,161,206,255);
                break;
        }
    }
}
