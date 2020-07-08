using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimSort;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Breeding Pair Selector creates a set of pairs descend sequentially in fitness.
    /// </summary>
    public class PairSelectorFittest : IBreedingPairSelector
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// This Breeding Pair Selector returns pairings descend sequentially in fitness.
        /// </summary>
        /// <param name="pPopulation"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<T> SelectPairs<T>(List<T> pPopulation) where T : GeneticEntity
        {
            T[] popArray = pPopulation.ToArray();
            TimSort<T>.sort(popArray, new GeneticEntityComparable());
            return new List<T>(popArray);
        }
    }
}
