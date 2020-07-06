using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Shop.Events;
using TimSort;
using VUSSK_GeneticEvolution;

public class UIReflect : MonoBehaviour
{
    [SerializeField] private Text clayOutput;
    [SerializeField] private Text siltOutput;
    [SerializeField] private Text sandOutput;

    [SerializeField] private Text pH_Output;

    [SerializeField] private Text sunHoursOutput;
    [SerializeField] private Text sunStrengthOutput;

    [SerializeField] private Text progressOutput;

    [SerializeField] private Text generationHighOutput;
    [SerializeField] private Slider generationHighSlider;
    [SerializeField] private Text generationAverageOutput;
    [SerializeField] private Slider generationAverageSlider;
    [SerializeField] private Text bedOutput;
    [SerializeField] private Color[] swatch;

    // Start is called before the first frame update
    void Start()
    {
        EventQueue.Subscribe(EventQueue.EventType.Soil_Update, UpdateSoilOutputs);
        EventQueue.Subscribe(EventQueue.EventType.Plot_Start, StartPlot);
        EventQueue.Subscribe(EventQueue.EventType.Plot_End, EndPlot);
        EventQueue.Subscribe(EventQueue.EventType.Plot_Reset, ResetPlot);
        EventQueue.Subscribe(EventQueue.EventType.BroadcastGeneration, BroadcastGeneration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartPlot(object sender, EventArgs e)
    {
        progressOutput.color = swatch[1];
        progressOutput.text = "Running...";
    }

    private void EndPlot(object sender, EventArgs e)
    {
        progressOutput.color = swatch[2];
        progressOutput.text = "Completed.";
    }

    private void ResetPlot(object sender, EventArgs e)
    {
        progressOutput.color = swatch[0];
        progressOutput.text = "Ready.";
    }

    private void BroadcastGeneration(object sender, EventArgs e)
    {
        generationHighOutput.text = ((GenerationArgs)e).high.ToString();
        generationHighSlider.value = ((GenerationArgs)e).high;
        generationAverageOutput.text = ((GenerationArgs)e).average.ToString();
        generationAverageSlider.value = ((GenerationArgs)e).average;
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
