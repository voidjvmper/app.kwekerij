using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public interface IMatingPoolSelector
    {
        List<GeneticEntity> SelectPool(List<GeneticEntity> pPopulation, int pSize);
    }
}