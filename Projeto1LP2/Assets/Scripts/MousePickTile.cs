using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePickTile : MonoBehaviour
{
    private Tile tileSpecifications;

    void OnMouseDown()
    {
        tileSpecifications = GetComponent<Tile>();
        Debug.Log(tileSpecifications.typeOfTile);    
    }
}
