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

    public Resource(string typeOfResource)
    {
        resourceDict.TryGetValue(typeOfResource, out _typeOfResource);
        DefineBaseValues();
    }

    private void DefineBaseValues()
    {
        switch(typeOfResource)
        {
            case ResourceType.Plants:
                extraGoldValue = 1;
                extraFoodValue = 2;
                break;
            case ResourceType.Animals:
                extraGoldValue = 2;
                extraFoodValue = 3;
                break;
            case ResourceType.Metals:
                extraGoldValue = 3;
                extraFoodValue = -1;
                break;
            case ResourceType.FossilFuel:
                extraGoldValue = 4;
                extraFoodValue = -2;
                break;
            case ResourceType.Luxury:
                extraGoldValue = 4;
                extraFoodValue = 0;
                break;
            case ResourceType.Pollution:
                extraGoldValue = -2;
                extraFoodValue = -3;
                break;
        }
    }
}
