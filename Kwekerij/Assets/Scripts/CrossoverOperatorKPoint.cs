using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Crossover Operator creates a list of children whose chromosomes have been crossed k-times at supplied or randomly chosen points in their parent's chromosome.
    /// </summary>
    public class CrossoverOperatorKPoint : ICrossoverOperator
    {
        int numberOfCrosses = int.MinValue;
        int[] crossoverPoints = null;

        public CrossoverOperatorKPoint(int pNumberOfCrosses, int[] pCrossoverPoints = null)
        {
            numberOfCrosses = pNumberOfCrosses;
            crossoverPoints = pCrossoverPoints;
        }

        /// <summary>
        /// This Crossover Operator returns a list of children whose chromosomes have been crossed k-times at supplied or randomly chosen points in their parent's chromosome.
        /// </summary>
        /// <param name="pBreedingPairs"></param>
        /// <returns></returns>
        public List<GeneticEntity> Crossover(List<GeneticEntity> pBreedingPairs)
        {
            //Run through our parent pairs, for half the length of the array, but jumping two steps each iteration
            for (int i = 0; i < pBreedingPairs.Count / 2; i = i + 2)
            {
                int[] childAChromosome = new int[pBreedingPairs[i].Chromosome.Length];
                int[] childBChromosome = new int[pBreedingPairs[i].Chromosome.Length];

                //Create a crossover point array with random values, if one is not supplied
                crossoverPoints = crossoverPoints == null ? CreateCrossoverPoints(childAChromosome.Length) : crossoverPoints;

                Vector2Int crossoverIndex = new Vector2Int();
                int timesCrossed = 0;

                //Used to refer to which parent's chromosome is being read 
                bool crossing = true;

                //Run through chromosome
                for (int j = 0; j < childAChromosome.Length; j++)
                {
                    //iterate the cross counter and invert the bool used for parent referencing
                    if (j == crossoverPoints[timesCrossed])
                    {
                        timesCrossed++;
                        crossing = !crossing;
                    }

                    //x contains parent A's index. y contains parent B's index
                    crossoverIndex.x = i; crossoverIndex.y = i + 1;

                    childAChromosome[j] = pBreedingPairs[crossoverIndex[System.Convert.ToInt32(crossing)]].Chromosome[j];
                    childBChromosome[j] = pBreedingPairs[crossoverIndex[System.Convert.ToInt32(!crossing)]].Chromosome[j];
                }
            }
            return pBreedingPairs;
        }

        /// <summary>
        /// Returns an int[] containing k positions to be used as crossover points
        /// </summary>
        /// <param name="chromosomeLength"></param>
        /// <returns></returns>
        private int[] CreateCrossoverPoints(int chromosomeLength)
        {
            crossoverPoints = new int[numberOfCrosses];
            for (int i = 0; i < numberOfCrosses; i++)
            {
                int rangeIndexOffset = i == 0 ? 0 : crossoverPoints[i - 1];
                crossoverPoints[i] = Random.Range(1 + rangeIndexOffset, chromosomeLength);
            }
            return crossoverPoints;
        }
    }
}


