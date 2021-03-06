﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//---------------------------------------------------------------
//          TODO: REPLACE WITH SCRIPTABLE OBJECTS
//---------------------------------------------------------------

public class Plant : MonoBehaviour
{
    [SerializeField] private string plantName;
    [Range(0, 24)]
    [SerializeField] private int sunHours;
    [Range(1, 4)]
    [SerializeField] private int sunStrength;
    [Range(0, 14)]
    [SerializeField] private float pHPreference;
    [Range(0, 100)]
    [SerializeField] private float clayPercentage;
    [Range(0, 100)]
    [SerializeField] private float siltPercentage;
    [Range(0, 100)]
    [SerializeField] private float sandPercentage;

    public string PlantName
    { get { return plantName; } }

    public int SunlightHours
    {
        get { return sunHours; }
    }

    public int SunlightStrength
    {
        get { return sunStrength; }
    }

    public float PHPreference
    {
        get { return pHPreference; }
    }

    public float ClayPercentage
    { get { return clayPercentage; } }

    public float SiltPercentage
    { get { return siltPercentage; } }

    public float SandPercentage
    { get { return sandPercentage; } }

}
