using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public interface IMatingPoolSelector
    {
        List<T> SelectPool<T>(List<T> pPopulation, int pSize) where T: GeneticEntity;
    }
}