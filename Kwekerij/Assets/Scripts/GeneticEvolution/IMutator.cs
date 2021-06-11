using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public interface IMutator
    {
        List<T> Mutate<T>(List<T> pPopulation) where T : GeneticEntity;
        //void ProcessChromosome<T>(Vector2Int pCrossoverIndex, List<T> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome) where T : GeneticEntity;
    }
}
