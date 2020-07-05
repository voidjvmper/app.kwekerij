using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimSort;
using System;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Breeding Pair Selector creates a set of pairs where the even numbers are always the fittest entity of the entire pool (the alpha) while odd numbers contain the next most fit entity descending sequentially. The first pairing contains two copies of the alpha and will therefore result in an asexually reproduced offspring. 
    /// </summary>
    public class PairSelectorAlphaA : IBreedingPairSelector
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
        /// This Breeding Pair Selector returns pairings where the even numbers are always the fittest entity of the entire pool (the alpha) while odd numbers contain the next most fit entity descending sequentially. The first pairing contains two copies of the alpha and will therefore result in an asexually reproduced offspring. 
        /// </summary>
        /// <param name="pPopulation"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<GeneticEntity> SelectPairs(List<GeneticEntity> pPopulation)
        {
            //Create a new list to return
            List<GeneticEntity> pairGrouping = new List<GeneticEntity>();

            //Sort by fittest
            TimSort<GeneticEntity>.sort(pPopulation.ToArray(), GeneticEntity.CompareFitness());

            //On even numbers we will always choose the fittest entity. On odd numbers we will chose
            //the next fittest entity in the pool
             for (int i = 0; i < pPopulation.Count; i++)
             {
                 int index = i % 2 == 0 ?
                     0 :
                     i / 2;

                pairGrouping.Add(pPopulation[index]);
             }
            return null;
        }

    }
}
