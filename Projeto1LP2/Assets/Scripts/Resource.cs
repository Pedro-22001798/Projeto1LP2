using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    private static readonly IDictionary<string, ResourceType> resourceDict = new Dictionary<string, ResourceType>()
    {
        {"plants", ResourceType.Plants},
        {"animals", ResourceType.Animals},
        {"metals", ResourceType.Metals},
        {"fossilfuel", ResourceType.FossilFuel},
        {"luxury", ResourceType.Luxury},
        {"pollution", ResourceType.Pollution}
    };

    ////////////
    // VARIABLES
    ////////////
    private ResourceType typeOfResource;
    private int extraGoldValue;
    private int extraFoodValue;

    ////////////
    // METHODS
    ////////////
    public ResourceType Type { get => typeOfResource; }
    public int GoldValue {get => extraGoldValue; }
    public int FoodValue {get => extraFoodValue; }
}
