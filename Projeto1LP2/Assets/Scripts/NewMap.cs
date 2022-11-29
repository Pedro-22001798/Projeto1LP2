using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMap : MonoBehaviour
{
    private int cols;
    private int rows;
    private Tile[,] tiles;

    public int Cols {get => cols;}
    public int Rows {get => rows;}
    
    public void DefineTile(int col, int row, Tile newTile)
    {
        tiles[col,row] = newTile;
    }

    public Tile GetTile(int col, int row)
    {
        return tiles[col,row];
    }

    public void DefineMapSize(int numCols, int numRows)
    {
        tiles = new Tile[numCols,numRows];
    }
}
