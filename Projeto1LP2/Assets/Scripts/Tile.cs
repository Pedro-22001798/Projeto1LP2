using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileVariables tileVariables;
    public TileVariables.typeOfTile typeOfTile;

    void Start()
    {
        tileVariables = GetComponent<TileVariables>();
        typeOfTile = tileVariables.chooseRandomTile();
        switch(typeOfTile)
        {
            case TileVariables.typeOfTile.desert:
                tileVariables.coin = 0;
                tileVariables.food = 0;
                break;
            case TileVariables.typeOfTile.plains:
                tileVariables.coin = 0;
                tileVariables.food = 2;
                break;
            case TileVariables.typeOfTile.hills:
                tileVariables.coin = 1;
                tileVariables.food = 1;
                break;
            case TileVariables.typeOfTile.mountain:
                tileVariables.coin = 1;
                tileVariables.food = 0;
                break;
            case TileVariables.typeOfTile.water:
                tileVariables.coin = 0;
                tileVariables.food = 1;
                break;
        }
    }

    void Update()
    {
        
    }
}
