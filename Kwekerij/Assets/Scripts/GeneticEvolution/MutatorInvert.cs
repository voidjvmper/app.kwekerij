using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class MutatorInvert : Mutator
    {
        //This code is almost identical to Scramble's. Find a way to reuse later
        protected override int[] InternalMutate<T>(T pEntity)
        {
  
            int rangeIndexA = Random.Range(0, pEntity.Chromosome.Length);

            //Start from A's end, wrap if longer
            int rangeIndexB = Random.Range(rangeIndexA, (pEntity.Chromosome.Length + rangeIndexA));

            //But first, before the modulo, calculate a length
            int rangeLength = rangeIndexB - rangeIndexA;
            rangeIndexB = rangeIndexB % pEntity.Chromosome.Length;

            List<int> mutatingRange = new List<int>();
            for (int i = rangeIndexA; i < rangeLength; i++)
            {
                mutatingRange.Add(pEntity.Chromosome[i % pEntity.Chromosome.Length]);
            }

            //Reverse instaed of Shuffle like Scramble
            mutatingRange.Reverse();

            int[] mutatedChromosome = pEntity.Chromosome;

            for (int i = 0; i < rangeLength; i++)
            {
                mutatedChromosome[(i + rangeIndexA) % mutatedChromosome.Length] = mutatingRange[i];
            }

            return mutatedChromosome;
        }
    }
}
