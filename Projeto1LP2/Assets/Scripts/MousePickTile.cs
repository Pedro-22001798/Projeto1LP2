using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickTile : MonoBehaviour
{
    private Tile tileSpecifications;
    private TileVariables tileVariables;

    void OnMouseDown()
    {
        tileSpecifications = GetComponent<Tile>();
        tileVariables = GetComponent<TileVariables>();
        Debug.Log(tileSpecifications.typeOfTile + " - coins= " + tileVariables.returnCoin() + " - food= " + tileVariables.returnFood());    
    }
}
