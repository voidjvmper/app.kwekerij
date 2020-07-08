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

        public static List<T> Evolve<T>(List<T> pPopulation, int pEvolvedPopulationSize, IMatingPoolSelector pPoolSelector, IBreedingPairSelector pPairSelector, ICrossoverOperator pOperator) where T: GeneticEntity
        {
            List<T> evolvedPopulation; 
            evolvedPopulation = pPoolSelector.SelectPool(pPopulation, pEvolvedPopulationSize);
            Debug.Log("Evolving pop step 1: " + evolvedPopulation[0].Fitness);
            evolvedPopulation = pPairSelector.SelectPairs(evolvedPopulation);
            Debug.Log("Evolving pop step 2: " + evolvedPopulation[0].Fitness);
            evolvedPopulation = pOperator.Crossover(evolvedPopulation);
            Debug.Log("Evolving pop step 3: " + evolvedPopulation[0].Fitness);

            return evolvedPopulation;
        }

    }
}
