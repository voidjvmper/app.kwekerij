using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public interface ICrossoverOperator 
    {
        List<GeneticEntity> Crossover(List<GeneticEntity> pPopulation);
    }
}


