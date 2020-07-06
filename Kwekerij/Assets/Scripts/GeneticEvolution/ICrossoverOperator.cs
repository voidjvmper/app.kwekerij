using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public interface ICrossoverOperator 
    {
        List<GeneticEntity> Crossover(List<GeneticEntity> pPopulation);
        void ProcessChromosome(Vector2Int pCrossoverIndex, List<GeneticEntity> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome);
    }
}


