using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Breeding Pair Selector creates a set of pairs where parents where chosen randomly from the supplied mating pool.
    /// </summary>
    public class PairSelectorNarrowRandom : IBreedingPairSelector
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
        /// This Breeding Pair Selector returns pairings where parents where chosen randomly from the supplied mating pool.
        /// </summary>
        /// <param name="pPopulation"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<GeneticEntity> SelectPairs(List<GeneticEntity> pPopulation)
        {
            Shuffler.Shuffle(ref pPopulation);
            return pPopulation;
        }
    }
}

