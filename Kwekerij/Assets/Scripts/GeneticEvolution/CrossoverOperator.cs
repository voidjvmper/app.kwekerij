using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class CrossoverOperator : ICrossoverOperator
    {
        protected int crossoverPoint = int.MinValue;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public List<GeneticEntity> Crossover(List<GeneticEntity> pBreedingPairs)
        {
            List<GeneticEntity> children = new List<GeneticEntity>();

            /*of 6
             0: 0 1
             2: 2 3
             4: 4 5*/

            //Run through our parent pairs, for half the length of the array, but jumping two steps each iteration
            for (int i = 0; i < pBreedingPairs.Count / 2; i = i + 2)
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

                children.Add(new GeneticEntity(childAChromosome, 0.0f));
                children.Add(new GeneticEntity(childBChromosome, 0.0f));
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

        public virtual void ProcessChromosome(Vector2Int pCrossoverIndex, List<GeneticEntity> pBreedingPairs, int pParentPairIndex, int pGeneIndex, ref int[] pChildAChromosome, ref int[] pChildBChromosome)
        {
           
        }
    }

}
