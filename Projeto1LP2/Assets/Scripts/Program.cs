using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private string[] files;
    int option;
    private List<string> listOfMaps;
    [SerializeField] private Dropdown mapOptionsDropDown;
    [SerializeField] private GameObject startUI;

    void Start()
    {
        files = Directory.GetFiles(path,extension);
        listOfMaps = new List<string>();
        mapOptionsDropDown.ClearOptions();
        for(int i = 0; i < files.Length; i++)
        {
            listOfMaps.Add(files[i]);
        }
        mapOptionsDropDown.AddOptions(listOfMaps);
    }

    public void DropDownValueChanged(Dropdown change)
    {
        option = mapOptionsDropDown.value;
    }

    public void StartGame()
    {
        startUI.SetActive(false);
        Game(files[option]);
    }

    void Game(string file)
    {
        lines = File.ReadAllLines(file);

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
                mapScript.DefineMapSize(rows,cols);
            }
            else
            {
                if(row < rows && col < cols)
                {
                    string[] line = lines[i].Split(" ");
                    bool commented = false;
                    List<Resource> tileResources2 = new List<Resource>();
                    for(int y = 0; y < line.Length; y++)
                    {
                        if(line[y] != "#")
                        {
                            if(!commented)
                            {
                                if(y == 0)
                                {
                                    mapTerrains[row,col] = line[y];
                                }
                                else
                                {
                                    tileResources.Add(line[y]);
                                    Resource newResource = new Resource(line[y]);
                                    tileResources2.Add(newResource);
                                }
                            }
                        }
                        else
                        {
                            commented = true;
                            break;
                        }
                    }

                    commented = false;
                    tileResources.Clear();

                    if(line[0] != "#")
                    {
                        Tile newTile = new Tile(mapTerrains[row,col], tileResources2);
                        mapScript.DefineTile(row,col,newTile);
                        Debug.Log(newTile.Terrain);
                        foreach(Resource r in newTile.Resources)
                            Debug.Log(r.typeOfResource);
                        col++;
                    }
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
