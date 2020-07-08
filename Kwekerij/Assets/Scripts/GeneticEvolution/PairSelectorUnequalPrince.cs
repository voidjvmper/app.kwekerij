using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TimSort;

namespace VUSSK_GeneticEvolution
{
    /// <summary>
    /// This Breeding Pair Selector creates a set of pairs where the first half of the even numbers contains the most fit parent, while the latter half contains the second most fit parent. The odd numbers descend sequentially through the remaining fittest entities.
    /// </summary>
    public class PairSelectorUnequalPrince : IBreedingPairSelector
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
        /// This Breeding Pair Selector returns pairings where the first half of the even numbers contains the most fit parent, while the latter half contains the second most fit parent. The odd numbers descend sequentially through the remaining fittest entities.
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

            //0A     1C
            //2A     3D
            //4A     5E
            //6B     7F
            //8B     9G
            //10B    11H


            for (int i = 0; i < popArray.Length; i++)
            {
                int index = i + 1;

                //If even
                if (i % 2 == 0)
                {
                    //First half of pool
                    if (i < popArray.Length / 2)
                    {
                        index = 0; //Prince A
                    }
                    //Latter half of pool
                    else
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



