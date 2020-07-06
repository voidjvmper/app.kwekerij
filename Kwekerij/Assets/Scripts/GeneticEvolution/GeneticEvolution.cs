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

        public static List<GeneticEntity> Evolve(List<GeneticEntity> pPopulation, int pEvolvedPopulationSize, IMatingPoolSelector pPoolSelector, IBreedingPairSelector pPairSelector, ICrossoverOperator pOperator)
        {
            List<GeneticEntity> evolvedPopulation = new List<GeneticEntity>();
            evolvedPopulation = pPoolSelector.SelectPool(pPopulation, pEvolvedPopulationSize);
            evolvedPopulation = pPairSelector.SelectPairs(evolvedPopulation);
            evolvedPopulation = pOperator.Crossover(evolvedPopulation);
            
            return evolvedPopulation;
        }

    }
}
