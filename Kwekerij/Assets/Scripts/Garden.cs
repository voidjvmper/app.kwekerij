using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

public class Garden : MonoBehaviour
{
    [SerializeField] private int seed;
    [SerializeField] private Patch[] patches;
    //TODO: Replace
    [SerializeField] private Plant[] availableSpecies;
    [Range(0, 50)]
    [SerializeField] private int numberOfBeds;
    private Bed[] beds;
    private bool initialised = false;
    // Start is called before the first frame update
    void Start()
    {
        CreateBeds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetPopulation()
    {
        CreateBeds();
    }

    public void EvolvePopulation()
    {
        if (!initialised)
        {
            CreateBeds();
        }
        for (int i = 0; i < beds.Length; i++)
        {
            beds[i].ComputeFitness();

        }
        GeneticEvolution.Evolve(beds, beds.Length, );
        //if !init
        //create
        //geneticevo.evolve
    }

    private int[] GenerateRandomChromosome(Vector2Int pMinMax, int pLength, int pRandomSeed)
    {
       Random.InitState(pRandomSeed);
        int[] chromosome = new int[pLength];
        for (int i = 0; i < chromosome.Length; i++)
        {
            chromosome[i] = Random.Range(pMinMax.x, pMinMax.y);
        }
        return chromosome;
    }

    public void FillBeds(int[] pChromosome = null)
    {
        for (int i = 0; i < beds.Length; i++)
        {
            int[] chromosome = pChromosome == null ? GenerateRandomChromosome(new Vector2Int(0, 4), patches.Length, seed) : pChromosome;
            beds[i] = new Bed(chromosome, 0.0f, patches);
        }
    }

    public void CreateBeds(int[] pChromosome = null)
    {
        beds = new Bed[numberOfBeds];
        for (int i = 0; i < beds.Length; i++)
        {
            int[] chromosome = pChromosome == null ? GenerateRandomChromosome(new Vector2Int(0, 4), patches.Length, seed) : pChromosome;
            beds[i] = new Bed(chromosome, 0.0f, patches);
        }
        initialised = true;
    }
}
