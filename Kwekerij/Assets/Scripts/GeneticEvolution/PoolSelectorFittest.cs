using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TimSort;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Mating Pool Selector creates a mating pool comprised of the fittest entities from the supplied population.
    /// </summary>
    public class PoolSelectorFittest : IMatingPoolSelector
    {
        public PoolSelectorFittest()
        {

        }

        /// <summary>
        /// This Mating Pool Selector returns a pool of the fittest entities from the supplied population.
        /// </summary>
        /// <param name="pPopulation"></param>
        /// <param name="pSize"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<T> SelectPool<T>(List<T> pPopulation, int pSize) where T: GeneticEntity
        {
            T[] matingArray = pPopulation.ToArray();
            TimSort<T>.sort(matingArray, new GeneticEntityComparable());
            return new List<T>(matingArray);
        }

    }
}