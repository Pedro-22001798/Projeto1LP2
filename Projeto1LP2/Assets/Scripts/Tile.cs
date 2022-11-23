using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private static readonly IDictionary<string, TerrainType> terrainDict = new Dictionary<string, TerrainType>()
    {
        {"desert", TerrainType.Desert},
        {"grassland", TerrainType.Grassland},
        {"hills", TerrainType.Hills},
        {"mountain", TerrainType.Mountain},
        {"ocean", TerrainType.Ocean}
    };
    
    private List<ResourceType> terrainResources = new List<ResourceType>();

    ////////////
    // VARIABLES
    ////////////
    [SerializeField] private TerrainType terrainType;
    private int defaultGoldValue;
    private int defaultFoodValue;
    private Color terrainColor;

    ////////////
    // METHODS
    ////////////
    public TerrainType Terrain {get => terrainType; }
    public Color Color {get => terrainColor; }

    public List<ResourceType> Resources
    {
        get
        {
            List<ResourceType> aux = new List<ResourceType>();

            foreach (ResourceType r in terrainResources)
                aux.Add(r);
            
            return aux;
        }
    }

    void Start()
    {
        terrainResources.Add(ResourceType.Plants);
        terrainResources.Add(ResourceType.Metals);
    }

    private void DefineBaseValues()
    {
        switch (Terrain)
        {
            case TerrainType.Desert:
                defaultGoldValue = 0;
                defaultFoodValue = 0;
                //terrainColor = new Color();
                break;
            
            case TerrainType.Grassland:
                defaultGoldValue = 0;
                defaultFoodValue = 2;
                //terrainColor = new Color();
                break;
            
            case TerrainType.Hills:
                defaultGoldValue = 1;
                defaultFoodValue = 1;
                //terrainColor = new Color();
                break;
            
            case TerrainType.Mountain:
                defaultGoldValue = 1;
                defaultFoodValue = 0;
                //terrainColor = new Color();
                break;

            case TerrainType.Ocean:
                defaultGoldValue = 0;
                defaultFoodValue = 1;
                //terrainColor = new Color();
                break;
        }
    }
}
