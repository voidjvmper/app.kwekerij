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
        public List<GeneticEntity> SelectPairs(List<GeneticEntity> pPopulation)
        {
            //Create a new list to return
            List<GeneticEntity> pairGrouping = new List<GeneticEntity>();

            //Sort by fittest
            TimSort<GeneticEntity>.sort(pPopulation.ToArray(), GeneticEntity.CompareFitness());

            //0A     1C
            //2A     3D
            //4A     5E
            //6B     7F
            //8B     9G
            //10B    11H


            for (int i = 0; i < pPopulation.Count; i++)
            {
                int index = i + 1;

                //If even
                if (i % 2 == 0)
                {
                    //First half of pool
                    if (i < pPopulation.Count / 2)
                    {
                        index = 0; //Prince A
                    }
                    //Latter half of pool
                    else
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



