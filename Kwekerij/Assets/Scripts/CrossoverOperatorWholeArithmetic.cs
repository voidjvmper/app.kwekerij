using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class CrossoverOperatorWholeArithmetic : ICrossoverOperator
    {
        float parentWeighting = 0.5f;

        /// <summary>
        /// Parent weighting should range between [0, 1], with the extremes fully favouring the genes of parent A or parent B respectively.
        /// </summary>
        /// <param name="pParentWeighting"></param>
        public CrossoverOperatorWholeArithmetic(float pParentWeighting = 0.5f)
        {
            parentWeighting = Mathf.Clamp01(pParentWeighting);
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

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

                    //α.x + (1-α).y
                    //parentWeighting * geneA + (1 - parentWeighting) * geneB
                }
            }
            return pBreedingPairs;
        }
    }
}
