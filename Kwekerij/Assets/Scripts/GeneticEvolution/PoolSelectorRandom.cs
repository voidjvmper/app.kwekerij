using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Mating Pool Selector creates a mating pool comprised of randomly chosen entities from the supplied population.
    /// </summary>
    public class PoolSelectorRandom : IMatingPoolSelector
    {
        public PoolSelectorRandom()
        {

        }

        /// <summary>
        /// This Mating Pool Selector returns a pool of randomly chosen entities from the supplied population.
        /// </summary>
        /// <param name="pPopulation"></param>
        /// <param name="pSize"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<GeneticEntity> SelectPool(List<GeneticEntity> pPopulation, int pSize)
        {            
            Shuffler.Shuffle(ref pPopulation);
            int size = (pSize <= pPopulation.Count && pSize > 0)? pSize : pPopulation.Count;

            //matingPool = pPopulation.OrderBy(a => Guid.NewGuid()).ToList();
            pPopulation.RemoveRange(size - 1, pPopulation.Count - size);
            return pPopulation;
        }
    }
}
