using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class CrossoverOperatorWholeArithmetic : CrossoverOperatorArithmetic
    {
        /// <summary>
        /// This Crossover Operator creates a list of children whose genes are a weighted average of both parents from the breeding parents pair.
        /// Child weighting should range between [0.0f, 1.0f], with the extremes fully favouring the genes of parent A or parent B respectively. If both children use the standard 0.5f weight, both children will be identical copies of one another and the perfect average of both parents.
        /// </summary>
        /// <param name="pChildAWeighting"></param>
        /// <param name="pChildBAWeighting"></param>
        public CrossoverOperatorWholeArithmetic(float pChildAWeighting = 0.5f, float pChildBWeighting = 0.5f) : base (pChildAWeighting, pChildBWeighting)
        {
           
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
      

        public override void ProcessChromosome<T>(Vector2Int pCrossoverIndex, List<T> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome)
        {
            //x contains parent A's index. y contains parent B's index
            pCrossoverIndex.x = pParentPairIndex; pCrossoverIndex.y = pParentPairIndex + 1;

            int geneA = pBreedingPairs[pCrossoverIndex[0]].Chromosome[pGeneIndex];
            int geneB = pBreedingPairs[pCrossoverIndex[1]].Chromosome[pGeneIndex];

            pChildAChromosome[pGeneIndex] = DoArithmetic(geneA, geneB, childWeighting.x);
            pChildBChromosome[pGeneIndex] = DoArithmetic(geneA, geneB, childWeighting.y);
        }
    }
}
