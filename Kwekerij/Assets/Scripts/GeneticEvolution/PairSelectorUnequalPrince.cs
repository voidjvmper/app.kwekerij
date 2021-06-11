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
        private const int princeOffset = 2; 
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

             //Debug.Log("pairGrouping size is: " + pairGrouping.Count);
            //Partner index is for the non-prince partner of the breeding pair
            int partnerIndex = princeOffset;

            //Prince index controls which prince is plugged in
            int princeIndex = 0;

            //Index is what gets plugged to the list
            int index = 0;

            //The pairing should exclude the two princes, and be equal to the remaining partners x2 
            //(since each partner needs the following slot to be filled by a prince)
            int lengthOfPairing = (popArray.Length - partnerIndex) * 2;

            //Debug.Log("poparray: " + popArray.Length);
            for (int i = 0; i < lengthOfPairing; i++)
            {
                //int index = i + 2;

                //To avoid duplication, we assume partner status and negate and switch to prince if need be
                index = partnerIndex;

                //If odd
                if (i % 1 == 0)
                {
                    //First half of pool
                    if (i < popArray.Length / 2)
                    {
                        princeIndex = 0; //Prince A
                    }
                    //Latter half of pool
                    else
                    {
                        princeIndex = 1; //Prince B
                    }
                    index = princeIndex;                    
                }
                else
                {
                    partnerIndex++;
                }

                

                //Debug.Log("i is: " + i + " while index is: " + index);
                //There is an unfixed OutOfRangeException here
                pairGrouping.Add( popArray[index]);
            }


            return pairGrouping;
        }
    }
}



