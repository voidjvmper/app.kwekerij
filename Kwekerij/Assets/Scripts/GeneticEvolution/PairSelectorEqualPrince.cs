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
        public List<T> SelectPairs<T>(List<T> pPopulation) where T : GeneticEntity
        {
            //Create a new list to return
            List<T> pairGrouping = new List<T>();
            T[] popArray = pPopulation.ToArray();
            //Sort by fittest
            TimSort<T>.sort(popArray, new GeneticEntityComparable());

            //0A     1B
            //2A     3C
            //4B     5D
            //6A     7E
            //8B     9F


            //Initial princely load
            pairGrouping.Add(popArray[0]);
            pairGrouping.Add(popArray[1]);

            for (int i = 2; i < popArray.Length; i++)
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

                pairGrouping.Add(popArray[index]);
            }


            return pairGrouping;
        }
    }
}


