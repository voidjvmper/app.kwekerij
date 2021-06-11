using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{

    public class MutatorReset : Mutator
    {

        protected override int[] InternalMutate<T>(T pEntity) 
        {
            int mutatedGeneIndex = Random.Range(0, pEntity.Chromosome.Length);
            int newMutationAllele = Random.Range((int)pEntity.AlleleLowerLimit, (int)pEntity.AlleleUpperLimit);
            int[] mutatedChromosome = pEntity.Chromosome;
            mutatedChromosome[mutatedGeneIndex] = newMutationAllele;
            return mutatedChromosome;
        }
    }
}
