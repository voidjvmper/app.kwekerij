using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

public class Bed : GeneticEntity
{
    private Garden garden;
    private Patch[] patches = null;
    public Bed(int[] pChromosome, float pFitness, Garden pGarden, Patch[] pPatches) : base(pChromosome, pFitness)
    {
        garden = pGarden;
        patches = pPatches;
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
        float overallFitness = 0.0f;
        const int TOTAL_FITNESS_PARAMETERS = 6;
        for (int i = 0; i < patches.Length; i++)
        {
            Soil soil = garden.Soil;
            Patch pat = patches[i];
            Plant plant = garden.availableSpecies[Chromosome[i]];

            float sunlightHoursFitness = DecimalFitness(pat.SunlightHours, plant.SunlightHours);
            float sunlightStrengthFitness = DecimalFitness(pat.SunlightStrength, plant.SunlightStrength);
            float pHFitness = DecimalFitness(soil.pH, plant.PHPreference);
            float clayFitness = DecimalFitness(soil.ClayPercentage, plant.ClayPercentage);
            float siltFitness = DecimalFitness(soil.SiltPercentage, plant.SiltPercentage);
            float sandFitness = DecimalFitness(soil.SandPercentage, plant.SandPercentage);

            float patchFitness = (sunlightHoursFitness + sunlightStrengthFitness + pHFitness + clayFitness + siltFitness + sandFitness) / TOTAL_FITNESS_PARAMETERS;
            overallFitness += patchFitness;
        }
        overallFitness /= patches.Length;
        UpdateFitness(overallFitness);
    }

    private float DecimalFitness(float pTotal, float pAttained)
    {
        return 1.0f - (pTotal - pAttained / pTotal);
    }
}
