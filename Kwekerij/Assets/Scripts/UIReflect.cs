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
    [SerializeField] private Text timeOutput;

    [SerializeField] private Text generationHighOutput;
    [SerializeField] private Slider generationHighSlider;
    [SerializeField] private Text generationAverageOutput;
    [SerializeField] private Slider generationAverageSlider;
    [SerializeField] private Text bedFitnessOutput;
    [SerializeField] private Color[] swatch;

    [SerializeField] private Image generationHighSliderFill;
    [SerializeField] private Image generationAvgSliderFill;
    [SerializeField] private Text generationCounter;

    [SerializeField] private Image loadingIcon;

    private int generationNumber;
    private string[] sunStrengthText = new string[]{ "Low", "Filtered", "Bright", "Outdoors" };
    private delegate void Updateables();
    private Updateables UpdateablesHandler;

    // Start is called before the first frame update
    void Start()
    {

        EventQueue.Subscribe(EventQueue.EventType.Soil_Update, UpdateSoilOutputs);
        EventQueue.Subscribe(EventQueue.EventType.Sun_Update, UpdateSunOutputs);
        EventQueue.Subscribe(EventQueue.EventType.BroadcastBeginGenerating, BeginPlot);
        EventQueue.Subscribe(EventQueue.EventType.Plot_End, EndPlot);
        EventQueue.Subscribe(EventQueue.EventType.Plot_Reset, ResetPlot);
        EventQueue.Subscribe(EventQueue.EventType.BroadcastGeneration, BroadcastGeneration);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateablesHandler?.Invoke();
        if (Input.GetKey(KeyCode.W))
        {
            SpinLoadingIcon();
        }
    }

    private void SpinLoadingIcon()
    {
        loadingIcon.transform.Rotate(new Vector3(0.0f, 0.0f, 1.0f));
    }
    private void BeginPlot(object sender, EventArgs e)
    {
        progressOutput.color = swatch[1];
        progressOutput.text = "Running...";
        EventQueue.QueueEvent(EventQueue.EventType.Plot_Start, this, new EventArgs());
        UpdateablesHandler += SpinLoadingIcon;
    }

    private void EndPlot(object sender, EventArgs e)
    {
        progressOutput.color = swatch[2];
        progressOutput.text = "Completed.";
        UpdateablesHandler -= SpinLoadingIcon;

        //Formats text for second or millisecond display
        const int MILLISECONDS = 1000;
        float timeDisplay = TimeLogger.Elapsed;
        string timeDisplayFormat = "ms";
        if (timeDisplay > MILLISECONDS)
        {
            timeDisplay /= MILLISECONDS;
            timeDisplay = Decimal.RoundToFactorOf(timeDisplay, 2.0f);
            timeDisplayFormat = "s";

        }
        string formattedDisplay =  timeDisplay.ToString().Replace(',', '.') + timeDisplayFormat;
        string timeText = TimeLogger.Elapsed < 15 ? "in < one frame." : "in " + formattedDisplay;
        timeOutput.text = timeText;
    }

    private void ResetPlot(object sender, EventArgs e)
    {
        generationNumber = 0;
        UpdateGenerationCounter();
        progressOutput.color = swatch[0];
        progressOutput.text = "> Ready.";

        generationHighOutput.text = 0.0f + "%";
        generationHighSlider.value = 0.0f;
        generationHighSliderFill.color = Color.white;

        generationAverageOutput.text = 0.0f + "%";
        generationAverageSlider.value = 0.0f;
        generationAvgSliderFill.color = Color.white;
    }

    private void UpdateGenerationCounter()
    {
        generationCounter.text = "G" + generationNumber;
    }

    private void BroadcastGeneration(object sender, EventArgs e)
    {
        GenerationArgs<Bed> arg = (GenerationArgs<Bed>)e;
        for (int i = 0; i < arg.population.Count; i++)
        {
            Debug.Log(String.Format("Bed {0}.", i));
            Patch[] patches = arg.population[i].Patches;
            for (int j = 0; j < patches.Length; j++)
            {
                Debug.Log(String.Format("Patch Square {0}. Output: {1}", j, arg.population[i].Chromosome[j]));
            }
           
        }
        generationNumber = arg.generationNumber;
        UpdateGenerationCounter();
        generationHighOutput.text = (Decimal.RoundToFactorOf(arg.high, 2.0f) * 100.0f).ToString() + "%";
        generationHighSlider.value = arg.high;

        //Color colourHigh = new Color();
        if (arg.high < 0.5f)
        {
            generationHighSliderFill.color = swatch[1];           
        }
        else if (arg.high > 0.5f && arg.high < 0.8f)
        {
            generationHighSliderFill.color = swatch[0];
        }
        else
        {
            generationHighSliderFill.color = swatch[2];
        }

        generationAverageOutput.text = (Decimal.RoundToFactorOf(arg.average, 2.0f) * 100.0f).ToString() + "%";
        generationAverageSlider.value = arg.average;


        if (arg.average < 0.5f)
        {

            generationAvgSliderFill.color = swatch[1];
        }
        else if (arg.average > 0.5f && arg.average < 0.8f)
        {
            generationAvgSliderFill.color = swatch[0];
        }
        else
        {
            generationAvgSliderFill.color = swatch[2];
        }
        
        string spacer = "\n";
        string dump = "";
        string extraSpaceDecimal = "";
        for (int i = 0; i < arg.population.Count; i++)
        {
            float round = Decimal.RoundToFactorOf(arg.population[i].Fitness, 2.0f);
            extraSpaceDecimal = round.ToString().Length <= 3 ? "0" : "";

            dump += round.ToString().Replace(',', '.') + extraSpaceDecimal + "  ";
            if (i % 3 == 0 && i != 0)
            {
                dump += spacer;
            }
        }
        bedFitnessOutput.text = dump;
    }

    private void UpdateSunOutputs(object sender, EventArgs e)
    {
        sunHoursOutput.text = String.Format("({0})Hrs", ((SunArgs)e).sunHours);
        sunStrengthOutput.text = String.Format("({0})", sunStrengthText[  ((SunArgs)e).sunStrength  -1] /*not zero indexed*/  );
    }

    private void UpdateSoilOutputs(object sender, EventArgs e)
    {
        string soilOutputText = "({0}%)";
        clayOutput.text = String.Format(soilOutputText, Mathf.Round(((SoilArgs)e).soilMakeup.x));
        siltOutput.text = String.Format(soilOutputText, Mathf.Round(((SoilArgs)e).soilMakeup.y));
        sandOutput.text = String.Format(soilOutputText, Mathf.Round(((SoilArgs)e).soilMakeup.z));
        pH_Output.text = String.Format("({0})", Decimal.RoundToFactorOf(((SoilArgs)e).soilMakeup.w, 1.0f));
    }

    private void PostMessage(object sender, EventArgs e)
    {
        //messageField.text = "> " + ((MessageArgs)e).message;
    }
}
