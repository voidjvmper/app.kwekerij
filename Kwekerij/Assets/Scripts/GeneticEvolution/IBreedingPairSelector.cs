using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public interface IBreedingPairSelector
    {
        List<GeneticEntity> SelectPairs(List<GeneticEntity> pBreedingPairs);
    }
}
