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
    [SerializeField] private TileFiller tileFillerScript;
    [SerializeField] private RestartGame restartGameScript;

    // FILE READING
    private string[] files;
    int option;
    private List<string> listOfMaps;
    [SerializeField] private Dropdown mapOptionsDropDown;

    // POSSIBLE ERROR
    [SerializeField] private Text errorText; 
    private bool error;
    private IEnumerator errorCoroutine;

    // UI
    [SerializeField] private GameObject startUI;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject[] futureButtons;
    [SerializeField] private GameObject errorUI;
    [SerializeField] private Text errorUIText;

    void Start()
    {
        restartButton.SetActive(false);
        errorUI.SetActive(false);

        files = Directory.GetFiles(path,extension);
        listOfMaps = new List<string>();
        mapOptionsDropDown.ClearOptions();

        for(int i = 0; i < files.Length; i++)
        {
            listOfMaps.Add(files[i]);
        }

        mapOptionsDropDown.AddOptions(listOfMaps);
        error = false;

        if(files.Length > 0)
        {
            errorText.text = $"Detected {files.Length} matching files!"; 
            errorText.color = Color.green;
        }
        else
        {
            errorText.text = "No files with *.map4x detected!";
            errorText.color = Color.red;            
        }

        for(int i = 0; i < futureButtons.Length; i++)
            futureButtons[i].SetActive(false);

        StartCoroutine("SearchForMaps");
    }

    private IEnumerator SearchForMaps()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            files = Directory.GetFiles(path,extension);
            listOfMaps = new List<string>();
            int prevOption = mapOptionsDropDown.value;
            mapOptionsDropDown.ClearOptions();

            for(int i = 0; i < files.Length; i++)
            {
                listOfMaps.Add(files[i]);
            }

            mapOptionsDropDown.AddOptions(listOfMaps);
            mapOptionsDropDown.value = option;
            error = false;

            if(files.Length > 0)
            {
                errorText.text = $"Detected {files.Length} matching files!"; 
                errorText.color = Color.green;
            }
            else
            {
                errorText.text = "No files with *.map4x detected!";
                errorText.color = Color.red;            
            }            
        }
    }

    public void DropDownValueChanged(Dropdown change)
    {
        if(listOfMaps.Count > 0)
            option = mapOptionsDropDown.value;
    }

    public void StartGame()
    {
        if(files.Length > 0)
        {
            startUI.SetActive(false);
            Game(files[option]); 
            StopCoroutine("SearchForMaps");
            restartButton.SetActive(true); 
            for(int i = 0; i < futureButtons.Length; i++)
                futureButtons[i].SetActive(true);   
        }
        else
        {
            errorText.text = "Can't start the game without a selected valid map!";
            errorText.color = Color.red;                  
        }
    }

    private IEnumerator DisplayError(string error)
    {
        errorUI.SetActive(true);
        errorUIText.text = error;
        yield return new WaitForSeconds(5f);
        errorUI.SetActive(false);
        errorUIText.text = string.Empty;
        restartGameScript.Restart();
    }

    void Game(string file)
    {
        lines = File.ReadAllLines(file);

        int col = 0;
        int row = 0;

        if(!error)
        {
            for(int i = 0; i < lines.Length; i++)
            {
                if(i == 0)
                {
                    string[] mapSize = lines[i].Split(" ");
                    int[] ints = new int[mapSize.Length];
                    for(int y = 0; y < mapSize.Length; y++) 
                    {
                        int number;
                        if(Int32.TryParse(mapSize[y], out number))
                            ints[y] = number;
                        else
                            Debug.Log("erro");
                    }
                    if(ints.Length == 2)
                    {
                        rows = ints[0];
                        cols = ints[1];
                        mapTerrains = new string[rows,cols];
                        mapScript.DefineMapSize(rows,cols);
                    }
                    else
                    {
                        error = true;
                        errorCoroutine = DisplayError("The map entered is not valid. You need to have both columns and rows on the first line of your map. Restarting game...");
                        StartCoroutine(errorCoroutine);
                    }
                }
                else
                {
                    if(!error)
                    {
                        if(row < rows && col < cols)
                        {
                            string[] line = lines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
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
                                            if(!tileResources.Contains(line[y]))
                                            {
                                                tileResources.Add(line[y]);
                                                Resource newResource = new Resource(line[y]);
                                                tileResources2.Add(newResource);
                                            }
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
            if(!error)
                tileFillerScript.FillMap(rows,cols);
        }
        error = false;
    }

    public void RestartGame()
    {
        restartButton.SetActive(false);
        option = 0;
        files = Directory.GetFiles(path,extension);
        listOfMaps = new List<string>();
        mapOptionsDropDown.ClearOptions();

        for(int i = 0; i < files.Length; i++)
        {
            listOfMaps.Add(files[i]);
        }

        mapOptionsDropDown.AddOptions(listOfMaps);
        error = false;

        if(files.Length > 0)
        {
            errorText.text = $"Detected {files.Length} matching files!"; 
            errorText.color = Color.green;
        }
        else
        {
            errorText.text = "No files with *.map4x detected!";
            errorText.color = Color.red;            
        }

        for(int i = 0; i < futureButtons.Length; i++)
            futureButtons[i].SetActive(false);

        StartCoroutine("SearchForMaps");        
    }
}
