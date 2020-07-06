using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shop.Events;

public class UIReflect : MonoBehaviour
{
    [SerializeField] private Text clayOutput;
    [SerializeField] private Text siltOutput;
    [SerializeField] private Text sandOutput;

    [SerializeField] private Text pH_Output;

    [SerializeField] private Text sunHoursOutput;
    [SerializeField] private Text sunStrengthOutput;

    [SerializeField] private Text progressOutput;

    [SerializeField] private Text generationAverageOutput;
    [SerializeField] private Slider generationAverageSlider;
    [SerializeField] private Text bedOutput;
    [SerializeField] private Color[] swatch;

    // Start is called before the first frame update
    void Start()
    {
        EventQueue.Subscribe(EventQueue.EventType.Soil_Update, UpdateSoilOutputs);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateSoilOutputs(object sender, EventArgs e)
    {
        string soilOutputText = "({0}%)";
        clayOutput.text = String.Format(soilOutputText, Mathf.Round(((SoilArgs)e).soilMakeup.x));
        siltOutput.text = String.Format(soilOutputText, Mathf.Round(((SoilArgs)e).soilMakeup.y));
        sandOutput.text = String.Format(soilOutputText, Mathf.Round(((SoilArgs)e).soilMakeup.z));
    }

    private void PostMessage(object sender, EventArgs e)
    {
        //messageField.text = "> " + ((MessageArgs)e).message;
    }
}
