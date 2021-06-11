using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Crossover Operator creates a list of children whose chromosomes have been crossed k-times at supplied or randomly chosen points in their parent's chromosome.
    /// </summary>
    public class CrossoverOperatorKPoint : CrossoverOperator
    {
        private int numberOfCrosses = int.MinValue;
        private int[] crossoverPoints = null;
        private int timesCrossed = 0;
        private bool crossing = true;

        public CrossoverOperatorKPoint(int pNumberOfCrosses = 2, int[] pCrossoverPoints = null)
        {
            numberOfCrosses = pNumberOfCrosses;
            crossoverPoints = pCrossoverPoints;
        }

        protected override void OptionalPreconditionsInitialisation()
        {
            timesCrossed = 0;

            //Used to refer to which parent's chromosome is being read 
            crossing = true;
        }

        protected override void DetermineCrossoverPoint(int pChromosomeLength)
        {
            //Create a crossover point array with random values, if one is not supplied
            crossoverPoints = crossoverPoints == null ? CreateCrossoverPoints(pChromosomeLength) : crossoverPoints;
        }

        public override void ProcessChromosome<T>(Vector2Int pCrossoverIndex, List<T> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome)
        {
            //Debug.Log("gene index: " + pGeneIndex + " cros[" + timesCrossed + "]: " );
            //iterate the cross counter and invert the bool used for parent referencing
            if (timesCrossed < numberOfCrosses && pGeneIndex == crossoverPoints[timesCrossed])
            {
                timesCrossed++;
                crossing = !crossing;
            }

            //x contains parent A's index. y contains parent B's index
            pCrossoverIndex.x = pParentPairIndex; pCrossoverIndex.y = pParentPairIndex + 1;

            pChildAChromosome[pGeneIndex] = pBreedingPairs[pCrossoverIndex[System.Convert.ToInt32(crossing)]].Chromosome[pGeneIndex];
            pChildBChromosome[pGeneIndex] = pBreedingPairs[pCrossoverIndex[System.Convert.ToInt32(!crossing)]].Chromosome[pGeneIndex];
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


