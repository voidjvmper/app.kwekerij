using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Crossover Operator creates a list of children whose genes are randomly chosen from their parents' on a per-gene basis with a weighted rating.
    /// </summary>
    public class CrossoverOperatorUniform : CrossoverOperator
    {
        private float parentWeighting = 0.5f;
        /// <summary>
        /// Parent weighting should range between [0, 1], with the extremes fully favouring the genes of parent A or parent B respectively.
        /// </summary>
        /// <param name="pParentWeighting"></param>
        public CrossoverOperatorUniform(float pParentWeighting = 0.5f)
        {
            parentWeighting = Mathf.Clamp01(pParentWeighting);
        }

        public override void ProcessChromosome(Vector2Int pCrossoverIndex, List<GeneticEntity> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome)
        {
            //x contains parent A's index. y contains parent B's index
            pCrossoverIndex.x = pParentPairIndex; pCrossoverIndex.y = pParentPairIndex + 1;

            float roll = Random.Range(0.0f, 1.0f);
            bool cross = roll > parentWeighting;

            pChildAChromosome[pGeneIndex] = pBreedingPairs[pCrossoverIndex[System.Convert.ToInt32(cross)]].Chromosome[pGeneIndex];
            pChildBChromosome[pGeneIndex] = pBreedingPairs[pCrossoverIndex[System.Convert.ToInt32(!cross)]].Chromosome[pGeneIndex];
        }
     }
}


