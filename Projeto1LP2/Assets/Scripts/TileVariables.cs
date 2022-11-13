using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileVariables : MonoBehaviour
{
    public enum typeOfTile
    {
        desert,
        plains,
        hills,
        mountain,
        water
    }

    public static typeOfTile chooseRandomTile()
    {
        var typeOfTileNum = Enum.GetNames(typeof(typeOfTile)).Length;
        int randomNum = UnityEngine.Random.Range(0,typeOfTileNum);
        return (typeOfTile)randomNum;
    }
}
