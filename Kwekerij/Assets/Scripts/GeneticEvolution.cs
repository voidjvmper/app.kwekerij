using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VOSSK_GeneticEvolution
{
    public class GeneticEvolution
    {
        //Chromosome (string): Solution
        //Gene (bits): Part of solution
        //Locus: Poisition of gene
        //Alleles: Value of gene
        //Phenotype: Decoded solution
        //Genotype: Encoded solution

        private List<GeneticEntity> population = new List<GeneticEntity>();
        private List<GeneticEntity> matingPool = new List<GeneticEntity>();

       

        public GeneticEvolution(List<GeneticEntity> pPopulation)
        {
            population = pPopulation;
        }


        public void Evolve(IMatingPoolSelector pPoolSelector)
        {
            int size = 0;
            pPoolSelector.Select(population, size);
        }


        //Crossover
        //
    }
}
