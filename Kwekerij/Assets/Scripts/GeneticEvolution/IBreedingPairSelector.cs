using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    
    public interface IBreedingPairSelector
    {
        List<T> SelectPairs<T>(List<T> pBreedingPairs) where T: GeneticEntity;
    }
}
