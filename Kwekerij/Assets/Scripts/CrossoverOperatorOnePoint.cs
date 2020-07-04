using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Crossover Operator creates a list of children whose chromosomes have been crossed at a supplied or randomly chosen single point in their parent's chromosome.
    /// </summary>
    public class CrossoverOperatorOnePoint : ICrossoverOperator
    {
        int crossoverPoint = int.MinValue;
        public CrossoverOperatorOnePoint(int pCrossoverPoint = int.MinValue)
        {

        }

        /// <summary>
        /// This Crossover Operator returns a list of children whose chromosomes have been crossed at a supplied or randomly chosen single point in their parent's chromosome.
        /// </summary>
        /// <param name="pBreedingPairs"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<GeneticEntity> Crossover(List<GeneticEntity> pBreedingPairs)
        {
            List<GeneticEntity> children = new List<GeneticEntity>();

            /*of 6
             0: 0 1
             2: 2 3
             4: 4 5*/
            
            //Run through our parent pairs, for half the length of the array, but jumping two steps each iteration
            for (int i = 0; i < pBreedingPairs.Count / 2; i = i + 2)
            {
                int[] childAChromosome = new int[pBreedingPairs[i].Chromosome.Length];
                int[] childBChromosome = new int[pBreedingPairs[i].Chromosome.Length];

                //Randomly select a crossover point, if one is not supplied
                crossoverPoint = crossoverPoint == int.MinValue ? Random.Range(1, childAChromosome.Length) : crossoverPoint;
                Vector2Int crossoverIndex = new Vector2Int();

                //Run through chromosome
                for (int j = 0; j < childAChromosome.Length; j++)
                {
                    //x contains parent A's index. y contains parent B's index
                    crossoverIndex.x = i; crossoverIndex.y = i + 1;
                    bool isBelowCrossoverPoint = j < crossoverPoint;

                    childAChromosome[j] = pBreedingPairs[crossoverIndex[System.Convert.ToInt32(isBelowCrossoverPoint)]].Chromosome[j];
                    childBChromosome[j] = pBreedingPairs[crossoverIndex[System.Convert.ToInt32(!isBelowCrossoverPoint)]].Chromosome[j];
                }

                children.Add(new GeneticEntity(childAChromosome, 0.0f));
            }

            return pBreedingPairs;

        }
    }

}

