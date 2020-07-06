using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimSort;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Breeding Pair Selector creates a set of pairs where the even numbers alternate between the two fittest parents, while the odd numbers descend sequentially through the remaining fittest entities.
    /// </summary>
    public class PairSelectorEqualPrince : IBreedingPairSelector
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
        /// This Breeding Pair Selector returns pairings where the even numbers alternate between the two fittest parents, while the odd numbers descend sequentially through the remaining fittest entities.
        /// </summary>
        /// <param name="pPopulation"></param>
        /// <returns>List of GeneticEntity</returns>
        public List<GeneticEntity> SelectPairs(List<GeneticEntity> pPopulation)
        {
            //Create a new list to return
            List<GeneticEntity> pairGrouping = new List<GeneticEntity>();

            //Sort by fittest
            TimSort<GeneticEntity>.sort(pPopulation.ToArray(), GeneticEntity.CompareFitness());

            //0A     1B
            //2A     3C
            //4B     5D
            //6A     7E
            //8B     9F


            //Initial princely load
            pairGrouping.Add(pPopulation[0]);
            pairGrouping.Add(pPopulation[1]);

            for (int i = 2; i < pPopulation.Count; i++)
            {
                int index = i;
                //If even
                if (i % 2 == 0)
                {
                    index = 0; //Prince A

                    //If every second even
                    if (i % 4 == 0)
                    {
                        index = 1; //Prince B
                    }
                }

                pairGrouping.Add(pPopulation[index]);
            }


            return pPopulation;
        }
    }
}


