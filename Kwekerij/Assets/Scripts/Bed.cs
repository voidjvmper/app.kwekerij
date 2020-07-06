using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

public class Bed : GeneticEntity
{
    private Patch[] patches = null;
    public Bed(int[] pChromosome, float pFitness, Patch[] pPatches) : base(pChromosome, pFitness)
    {
        patches = pPatches;
    }
    [SerializeField] private int seed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
