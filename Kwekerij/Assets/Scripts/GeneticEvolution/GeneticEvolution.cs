using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop.Events;

namespace VUSSK_GeneticEvolution
{
    public static class GeneticEvolution
    {
        //Chromosome (string): Solution
        //Gene (bits): Part of solution
        //Locus: Poisition of gene
        //Alleles: Value of gene
        //Phenotype: Decoded solution
        //Genotype: Encoded solution

        public static List<T> Evolve<T>(List<T> pPopulation, int pEvolvedPopulationSize, IMatingPoolSelector pPoolSelector, IBreedingPairSelector pPairSelector, ICrossoverOperator pOperator, IMutator pMutator) where T: GeneticEntity
        {
            List<T> pooledPop = new List<T>();
            List<T> pairedPop = new List<T>();
            List<T> crossedPop = new List<T>();
            List<T> mutatedPop = new List<T>();

            int stepCount = 1;

            //Select Pool
            pooledPop = pPoolSelector.SelectPool(pPopulation, pEvolvedPopulationSize);
            OutputStep(pooledPop, stepCount, "pooling");           
            stepCount++;

            //Select Pairs
            pairedPop = pPairSelector.SelectPairs(pooledPop);
            OutputStep(pairedPop, stepCount, "pairing");            
            stepCount++;

            //Crossover
            crossedPop = pOperator.Crossover(pairedPop);
            OutputStep(crossedPop, stepCount, "crossing");            
            stepCount++;

            //Mutate
            mutatedPop = pMutator.Mutate(crossedPop);
            OutputStep(pooledPop, stepCount, "mutating");            
            stepCount++;

            return mutatedPop;
        }

        public static void OutputStep<T>(List<T> pPopulation, int pStepCount, string pIdentifier) where T : GeneticEntity
        {
            string stepText = "(Evolving pop step " + pStepCount + " (" + pIdentifier + ")) - Size: " + pPopulation.Count + " | Fitness: " + pPopulation[0].Fitness;
            //Debug.Log(stepText);
        }

    }
}
