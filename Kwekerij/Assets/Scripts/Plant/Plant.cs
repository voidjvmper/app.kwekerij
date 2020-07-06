using System.Collections;
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
    [Range(0, 3)]
    [SerializeField] private int sunStrength;
    [Range(0, 14)]
    [SerializeField] private float pHPreference;
    [Range(0, 100)]
    [SerializeField] private float clayPercentage;
    [Range(0, 100)]
    [SerializeField] private float siltPercentage;
    [Range(0, 100)]
    [SerializeField] private float sandPercentage;



}
