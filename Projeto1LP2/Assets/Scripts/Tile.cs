using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileVariables.typeOfTile typeOfTile;

    void Start()
    {
        typeOfTile = TileVariables.chooseRandomTile();    
    }

    void Update()
    {
        
    }
}
