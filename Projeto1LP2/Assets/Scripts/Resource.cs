using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : IResource
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
    private ResourceType _typeOfResource;
    private int extraGoldValue;
    private int extraFoodValue;

    ////////////
    // METHODS
    ////////////
    public ResourceType typeOfResource { get => _typeOfResource; }
    public int gold {get => extraGoldValue; }
    public int food {get => extraFoodValue; }
}
