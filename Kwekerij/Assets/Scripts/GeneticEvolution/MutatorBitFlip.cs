using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class MutatorBitFlip : Mutator
    {

        protected override int[] InternalMutate<T>(T pEntity)
        {
            int mutatedGeneIndex = Random.Range(0, pEntity.Chromosome.Length);

            int alleleLower = (int)pEntity.AlleleLowerLimit;
            int alleleUpper = (int)pEntity.AlleleUpperLimit;
            int alleleRange = alleleUpper - alleleLower;

            //We use a float since traditional 'bit'flipping is binary, although here they can be represented by ints of 1 and 0
            float flippedAllele = float.MinValue;
            
                //find the halfway point and the difference and then flip the value by the difference around the mid point
                float alleleHalfwayPoint = alleleRange / 2.0f;
                if (pEntity.Chromosome[mutatedGeneIndex] < alleleHalfwayPoint)
                {
                    float difference = alleleHalfwayPoint - pEntity.Chromosome[mutatedGeneIndex];
                    flippedAllele = alleleHalfwayPoint + difference;
                }
                else
                {
                    float difference = pEntity.Chromosome[mutatedGeneIndex] - alleleHalfwayPoint;
                    flippedAllele = alleleHalfwayPoint - difference;
                }

            int[] mutatedChromosome = pEntity.Chromosome;
            //since we used a float for 0/1 operations, just cast it back to an int: mathematically it should have done so already
            mutatedChromosome[mutatedGeneIndex] = (int)flippedAllele;

           
            return mutatedChromosome;
        }
    }
}


