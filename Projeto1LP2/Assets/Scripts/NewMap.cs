using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewMap : MonoBehaviour
{
    private int cols;
    private int rows;
    private Tile[,] tiles;

    public int Cols {get => cols;}
    public int Rows {get => rows;}
    
    public void DefineTile(int row, int col, Tile newTile)
    {
        tiles[row,col] = newTile;
    }

    public Tile GetTile(int row, int col)
    {
        return tiles[row,col];
    }

    public void DefineMapSize(int numRows, int numCols)
    {
        tiles = new Tile[numRows,numCols];
    }
}
