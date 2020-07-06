using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soil : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] private float clayPercentage;
    [Range(0, 100)]
    [SerializeField] private float siltPercentage;
    [Range(0, 100)]
    [SerializeField] private float sandPercentage;
    [Range(0, 14)]
    [SerializeField] private float soil_pH;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float ClayPercentage
    { get { return clayPercentage; } }

    public float SiltPercentage
    { get { return siltPercentage; } }

    public float SandPercentage
    { get { return sandPercentage; } }

    public float pH
    { get { return soil_pH; } }

}
