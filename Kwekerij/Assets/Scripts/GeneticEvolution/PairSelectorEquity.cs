using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimSort;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Breeding Pair Selector creates a set of pairs where the even numbers are the given mating pool's fittest and the odd are its least fit. This grouping is used to pair the fittest entities with the least fit together.
    /// </summary>
    public class PairSelectorEquity : IBreedingPairSelector
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
        /// This Breeding Pair Selector returns pairings where the even numbers are the given mating pool's fittest and the odd are its least fit. This grouping is used to pair the fittest entities with the least fit together.
        /// </summary>
        /// <param name="pPopulation"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<GeneticEntity> SelectPairs(List<GeneticEntity> pPopulation)
        {
            //Create a new list to return
            List<GeneticEntity> pairGrouping = new List<GeneticEntity>();

            //Sort our pool by entity fitness
            TimSort<GeneticEntity>.sort(pPopulation.ToArray(), GeneticEntity.CompareFitness());

            //Loop through the pool 
            for (int i = 0; i < pPopulation.Count; i++)
            {
                //Our chosen index will be i / 2 (the fittest) on even numbers while the least fittest 
                //on odd numbers, using list.count - 1 (accounting for zero-indexing) minus 
                //the loop's iteration                
                int index = i % 2 == 0 ?
                    (i / 2) :
                    (pPopulation.Count - 1) - i;

                pairGrouping.Add(pPopulation[index]);
            }
            return pPopulation;
        }
    }
}

