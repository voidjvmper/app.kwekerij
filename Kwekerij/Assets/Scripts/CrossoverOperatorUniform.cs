using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Crossover Operator creates a list of children whose genes are randomly chosen from their parents' on a per-gene basis with a weighted rating.
    /// </summary>
    public class CrossoverOperatorUniform : ICrossoverOperator
    {
        float parentWeighting = 0.5f;
        /// <summary>
        /// Parent weighting should range between [0, 1], with the extremes fully favouring the genes of parent A or parent B respectively.
        /// </summary>
        /// <param name="pParentWeighting"></param>
        public CrossoverOperatorUniform(float pParentWeighting = 0.5f)
        {
            parentWeighting = Mathf.Clamp01(pParentWeighting);
        }

        /// <summary>
        /// This Crossover Operator returns a list of children whose genes are randomly chosen from their parents' on a per-gene basis with the supplied weighting.
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

                Vector2Int crossoverIndex = new Vector2Int();

                //Run through chromosome
                for (int j = 0; j < childAChromosome.Length; j++)
                {
                    //x contains parent A's index. y contains parent B's index
                    crossoverIndex.x = i; crossoverIndex.y = i + 1;

                    float roll = Random.Range(0.0f, 1.0f);                
                    bool cross = roll > parentWeighting;

                    childAChromosome[j] = pBreedingPairs[crossoverIndex[System.Convert.ToInt32(cross)]].Chromosome[j];
                    childBChromosome[j] = pBreedingPairs[crossoverIndex[System.Convert.ToInt32(!cross)]].Chromosome[j];
                }
            }
            return pBreedingPairs;
        }
    }
}


