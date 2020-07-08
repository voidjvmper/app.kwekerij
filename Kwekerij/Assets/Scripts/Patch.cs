using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patch : MonoBehaviour
{
    [Range(0, 24)]
    [SerializeField] private int sunlightHours;
    [Range(1, 4)]
    [SerializeField] private int sunlightStrength;
    private Plant plant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int SunlightHours
    {
        get { return sunlightHours; }
    }

    public int SunlightStrength
    {
        get { return sunlightStrength; }
    }

    public Plant Plant
    { get { return plant; } }

}
