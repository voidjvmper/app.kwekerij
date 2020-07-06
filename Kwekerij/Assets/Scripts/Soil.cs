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
}
