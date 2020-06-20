using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VOSSK_GeneticEvolution
{
    public interface IMatingPoolSelector
    {
        List<GeneticEntity> Select(List<GeneticEntity> pPopulation, int pSize);
    }
}