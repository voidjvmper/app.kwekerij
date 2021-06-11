using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class MutatorSwap : Mutator
    {


        protected override int[] InternalMutate<T>(T pEntity)
        {
            int tempAllele = int.MinValue;
            int mutatedGeneIndexA = Random.Range(0, pEntity.Chromosome.Length);
            int mutatedGeneIndexB = Random.Range(0, pEntity.Chromosome.Length);

            //If B happens to also roll the same index as A, just increase it by one, modulo the length
            mutatedGeneIndexB = mutatedGeneIndexB == mutatedGeneIndexA ? (mutatedGeneIndexB + 1 % pEntity.Chromosome.Length) : mutatedGeneIndexB;

            int[] mutatedChromosome = pEntity.Chromosome;

            //Classic flip
            tempAllele = mutatedChromosome[mutatedGeneIndexA];
            mutatedChromosome[mutatedGeneIndexA] = mutatedChromosome[mutatedGeneIndexB];
            mutatedChromosome[mutatedGeneIndexB] = mutatedChromosome[tempAllele];

            return mutatedChromosome;
        }
    }
}
