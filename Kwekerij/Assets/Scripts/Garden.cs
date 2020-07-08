using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;
using Shop.Events;
using System.Linq;
using TimSort;

public class Garden : MonoBehaviour
{
    [SerializeField] Testbench testbench;
    [SerializeField] private int seed;
    [SerializeField] private Soil soil;
    [SerializeField] private Patch[] patches;
    //TODO: Replace
    [SerializeField] public Plant[] availableSpecies;
    [Range(0, 50)]
    [SerializeField] private int numberOfBeds;
    private List<Bed> beds;
    private bool initialised = false;
    private int generationNumber = 0;
    private int givenIterations = 1;
    // Start is called before the first frame update
    void Start()
    {
        GeneticEntity.SeedRandom(seed);
        
        soil = GetComponent<Soil>();
        ResetPopulation();

        EventQueue.Subscribe(EventQueue.EventType.Plot_Start, EvolvePopulation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPopulation()
    {
        CreateBeds();
        generationNumber = 0;
        EventQueue.QueueEvent(EventQueue.EventType.Plot_Reset, this, new TimeArgs(Time.realtimeSinceStartup));
    }

    private void EvolvePopulation(object sender, EventArgs e)
    {
        TimeLogger.LogStart();
        float averageFitness = 0.0f;
        for (int g = 0; g < givenIterations; g++)
        {

            if (!initialised)
            {
                CreateBeds();
            }
            /*for (int i = 0; i < beds.Count; i++)
            {
                beds[i].ComputeFitness();
            }*/
            beds = GeneticEvolution.Evolve(beds, beds.Count, testbench.GetUsedMatingPoolSelector(), testbench.GetUsedBreedingPairSelector(), testbench.GetUsedCrossoverOperator());
            for (int i = 0; i < beds.Count; i++)
            {
                beds[i].LoadGardenAndPatches(this, patches);
            }
            generationNumber++;

            //Debug.Log("Unsorted List " + beds[0].Fitness);
            Bed[] bedArray = beds.ToArray();
            TimSort<Bed>.sort(bedArray, new GeneticEntityComparable());
            /* for (int i = 0; i < bedArray.Length; i++)
             {
                 Debug.Log("Sorted post-gen i: " + i + " Fitness: " + bedArray[i].Fitness);
             }*/
            //Debug.Log("Top of Array: " + bedArray[0].Fitness);
            beds = new List<Bed>(bedArray);

            averageFitness = 0.0f;
            for (int i = 0; i < beds.Count; i++)
            {
                averageFitness += beds[i].Fitness;
                // Debug.Log("Beds [" + i + "]:" + beds[i].Fitness);
            }
            averageFitness /= beds.Count;
            //EventQueue.QueueEvent(EventQueue.EventType.BroadcastGeneration, this, new GenerationArgs<Bed>(beds, beds[0].Fitness, averageFitness, generationNumber));

        }
        TimeLogger.LogEnd();
        EventQueue.QueueEvent(EventQueue.EventType.Plot_End, this, new TimeArgs(Time.realtimeSinceStartup));
        EventQueue.QueueEvent(EventQueue.EventType.BroadcastGeneration, this, new GenerationArgs<Bed>(beds, beds[0].Fitness, averageFitness, generationNumber));
    }

    public void StartEvolveProcess(int pIterations)
    {
        givenIterations = pIterations;
        
        EventQueue.QueueEvent(EventQueue.EventType.BroadcastBeginGenerating, this, new TimeArgs(Time.realtimeSinceStartup));
        
        //if !init
        //create
        //geneticevo.evolve
    }


    /*public void FillBeds(int[] pChromosome = null)
    {
        for (int i = 0; i < beds.Count; i++)
        {
            int[] chromosome = pChromosome == null ? GeneticEntity.GenerateRandomChromosome(new Vector2Int(0, 4), patches.Length, seed) : pChromosome;
            beds[i] = new Bed(chromosome, 0.0f, patches);
        }
    }*/

    public void CreateBeds(int[] pChromosome = null)
    {
        beds = new List<Bed>();
        for (int i = 0; i < numberOfBeds; i++)
        {
            int[] chromosome = pChromosome == null ? GeneticEntity.GenerateRandomChromosome(new Vector2Int(0, 4), patches.Length, seed) : pChromosome;
            beds.Add(new Bed(chromosome, this, patches));
        }
        initialised = true;
    }

    public Soil Soil
    {
        get { return soil; }
    }
}
