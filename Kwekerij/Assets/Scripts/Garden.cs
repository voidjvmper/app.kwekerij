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
    private List<GeneticEntity> beds;
    private bool initialised = false;
    // Start is called before the first frame update
    void Start()
    {
        soil = GetComponent<Soil>();
        CreateBeds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPopulation()
    {
        CreateBeds();
        EventQueue.QueueEvent(EventQueue.EventType.Plot_Reset, this, new TimeArgs(Time.time));
    }

    public void EvolvePopulation()
    {
        EventQueue.QueueEvent(EventQueue.EventType.Plot_Start, this, new TimeArgs(Time.time));
        if (!initialised)
        {
            CreateBeds();
        }
        for (int i = 0; i < beds.Count; i++)
        {
            beds[i].ComputeFitness();
        }
        GeneticEvolution.Evolve(ref beds, beds.Count, testbench.GetUsedMatingPoolSelector(), testbench.GetUsedBreedingPairSelector(), testbench.GetUsedCrossoverOperator()); 
        EventQueue.QueueEvent(EventQueue.EventType.Plot_End, this, new TimeArgs(Time.time));
        TimSort<GeneticEntity>.sort(beds.ToArray(), GeneticEntity.CompareFitness());
        float averageFitness = 0.0f;
        for (int i = 0; i < beds.Count; i++)
        {
            averageFitness += beds[i].Fitness;
        }
        averageFitness /= beds.Count;
        EventQueue.QueueEvent(EventQueue.EventType.BroadcastGeneration, this, new GenerationArgs(beds, beds[0].Fitness, averageFitness));
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
        beds = new List<GeneticEntity>();
        for (int i = 0; i < beds.Count; i++)
        {
            int[] chromosome = pChromosome == null ? GeneticEntity.GenerateRandomChromosome(new Vector2Int(0, 4), patches.Length, seed) : pChromosome;
            beds.Add(new Bed(chromosome, 0.0f, this, patches));
        }
        initialised = true;
    }

    public Soil Soil
    {
        get { return soil; }
    }
}
