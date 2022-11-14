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
    
    ////////////
    // VARIABLES
    ////////////
    private TerrainType terrainType;
    private int defaultGoldValue;
    private int defaultFoodValue;

    ////////////
    // METHODS
    ////////////
    public TerrainType Terrain {get => terrainType; }
}
