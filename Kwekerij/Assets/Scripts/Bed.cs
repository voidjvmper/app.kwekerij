using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using VUSSK_GeneticEvolution;

public class Bed : GeneticEntity
{
    private Garden garden;
    private Patch[] patches = null;
    public Bed(int[] pChromosome, Vector2Int pAcceptedAlleleRange,/*float pFitness,*/ Garden pGarden, Patch[] pPatches) : base(pChromosome, pAcceptedAlleleRange/*, pFitness*/)
    {
        garden = pGarden;
        patches = pPatches;
        ComputeFitness();
    }

    public Bed(int[] pChromosome, Vector2Int pAcceptedAlleleRange) : base(pChromosome, pAcceptedAlleleRange)
    {

    }

    /// <summary>
    /// Used for loading after instance has been constructed from elsewhere
    /// </summary>
    /// <param name="pGarden"></param>
    /// <param name="pPatches"></param>
    public void LoadGardenAndPatches(Garden pGarden, Patch[] pPatches)
    {
        garden = pGarden;
        patches = pPatches;
        ComputeFitness();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void ComputeFitness()
    {
        if (garden == null || patches == null)
        {
            return;
        }
        //Debug.Log("Bed compo");
        float overallFitness = 0.0f;
        const int TOTAL_FITNESS_PARAMETERS = 6;
        //Debug.Log("----Bed");
        for (int i = 0; i < patches.Length; i++)
        {
            Soil soil = garden.Soil;
            Patch patch = patches[i];
            Plant plant = garden.availableSpecies[Chromosome[i]];

            float sunlightHoursFitness = DecimalFitness(patch.SunlightHours, plant.SunlightHours);
            float sunlightStrengthFitness = DecimalFitness(patch.SunlightStrength, plant.SunlightStrength);
            float pHFitness = DecimalFitness(soil.pH, plant.PHPreference);
            float clayFitness = DecimalFitness(soil.ClayPercentage, plant.ClayPercentage);
            float siltFitness = DecimalFitness(soil.SiltPercentage, plant.SiltPercentage);
            float sandFitness = DecimalFitness(soil.SandPercentage, plant.SandPercentage);

            float patchFitness = (sunlightHoursFitness + sunlightStrengthFitness + pHFitness + clayFitness + siltFitness + sandFitness) / TOTAL_FITNESS_PARAMETERS;
            overallFitness += patchFitness;
        }
        overallFitness /= patches.Length;
        SetFitness(overallFitness);
    }

    private float DecimalFitness(float pTotal, float pAttained)
    {
        float fitness = 1.0f - (pTotal - pAttained) / pTotal;
        if (fitness > 1.0f)
        {
            fitness -= 1.0f;
            fitness *= -1.0f;
        }
        return fitness;
    }

    public Patch[] Patches
    { get { return patches; } }
}
