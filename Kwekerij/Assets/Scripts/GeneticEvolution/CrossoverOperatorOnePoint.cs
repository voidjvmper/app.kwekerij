using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Crossover Operator creates a list of children whose chromosomes have been crossed at a supplied or randomly chosen single point in their parent's chromosome.
    /// </summary>
    public class CrossoverOperatorOnePoint : CrossoverOperator
    {
        public CrossoverOperatorOnePoint(int pCrossoverPoint = int.MinValue)
        {
            crossoverPoint = pCrossoverPoint;
        }        

        public override void ProcessChromosome<T>(Vector2Int pCrossoverIndex, List<T> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome)
        {
            //x contains parent A's index. y contains parent B's index
            pCrossoverIndex.x = pParentPairIndex; pCrossoverIndex.y = pParentPairIndex + 1;
            bool isBelowCrossoverPoint = pGeneIndex < crossoverPoint;

            pChildAChromosome[pGeneIndex] = pBreedingPairs[pCrossoverIndex[System.Convert.ToInt32(isBelowCrossoverPoint)]].Chromosome[pGeneIndex];
            pChildBChromosome[pGeneIndex] = pBreedingPairs[pCrossoverIndex[System.Convert.ToInt32(!isBelowCrossoverPoint)]].Chromosome[pGeneIndex];
        }
    }

}

