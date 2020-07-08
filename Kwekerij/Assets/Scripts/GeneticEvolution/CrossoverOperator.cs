using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class CrossoverOperator : ICrossoverOperator
    {
        protected int crossoverPoint = int.MinValue;
        
        public CrossoverOperator()
        {

        }

        public List<T> Crossover<T>(List<T> pBreedingPairs) where T: GeneticEntity
        {
            List<T> children = new List<T>();

            /*of 6
             0: 0 1
             2: 2 3
             4: 4 5*/

            //Run through our parent pairs, for half the length of the array, but jumping two steps each iteration
            for (int i = 0; i < pBreedingPairs.Count; i = i + 2)
            {
                int[] childAChromosome = new int[pBreedingPairs[i].Chromosome.Length];
                int[] childBChromosome = new int[pBreedingPairs[i].Chromosome.Length];

                DetermineCrossoverPoint(childAChromosome.Length);
                OptionalPreconditionsInitialisation();
                Vector2Int crossoverIndex = new Vector2Int();

                //Run through chromosome
                for (int j = 0; j < childAChromosome.Length; j++)
                {
                    ProcessChromosome(crossoverIndex, pBreedingPairs, i, j, ref childAChromosome, ref childBChromosome);                    
                }

                //(T)Activator.CreateInstance(ObjectType);
                //return (T)Activator.CreateInstance(typeof(T), args);
                //https://stackoverflow.com/questions/25577601/constructor-on-type-not-found
                //Array covariance constructor issue
                children.Add((T)System.Activator.CreateInstance(typeof(T), new object[] { childAChromosome }));
                children.Add((T)System.Activator.CreateInstance(typeof(T), new object[] { childBChromosome }));
            }

            return children;
        }

        /// <summary>
        /// This method can be overloaded by any child class to initialise local values before the crossover opetaion.
        /// </summary>
        protected virtual void OptionalPreconditionsInitialisation()
        {

        }
        protected virtual void DetermineCrossoverPoint(int pChromosomeLength)
        {
            //Randomly select a crossover point, if one is not supplied
            crossoverPoint = crossoverPoint == int.MinValue ? Random.Range(1, pChromosomeLength) : crossoverPoint;
        }

        public virtual void ProcessChromosome<T>(Vector2Int pCrossoverIndex, List<T> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome) where T : GeneticEntity
        {
           
        }
    }

}
