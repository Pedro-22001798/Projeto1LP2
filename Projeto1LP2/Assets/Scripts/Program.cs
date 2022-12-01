using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Program : MonoBehaviour
{
    private string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\map4xfiles";
    //private string path = "C:/Users/werds/Desktop/map4xfiles";
    private string extension = "*.map4x";
    private string[] lines;

    // DEFINE MAP
    private int rows;
    private int cols;
    private string[,] mapTerrains;
    private List<string> tileResources = new List<string>();
    
    // SCRIPTS
    [SerializeField] private NewMap mapScript;

    void Start()
    {
        string[] file = Directory.GetFiles(path,extension);
        lines = File.ReadAllLines(file[0]);

        int col = 0;
        int row = 0;

        for(int i = 0; i < lines.Length; i++)
        {
            if(i == 0)
            {
                string[] mapSize = lines[i].Split(" ");
                int[] ints = new int[mapSize.Length];
                for(int y = 0; y < mapSize.Length; y++) ints[y] = Int32.Parse(mapSize[y]);
                rows = ints[0];
                cols = ints[1];
                mapTerrains = new string[rows,cols];
            }
            else
            {
                if(row < rows && col < cols)
                {
                    string[] line = lines[i].Split(" ");
                    if(line[0] != "#")
                    {
                        for(int y = 0; y < line.Length; y++)
                        {
                            if(y == 0)
                            {
                                mapTerrains[row,col] = line[y];
                            }
                            else
                            {
                                tileResources.Add(line[y]);
                            }
                        }
                        tileResources.Clear();

                        col++;
                        if(col == cols)
                        {
                            col = 0;
                            row++;
                        }
                    }
                }
            }
        }
    }
}
