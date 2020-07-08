using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class GeneticEntity 
    {
        private int[] chromosome;
        protected float fitness;

        public GeneticEntity(int[] pChromosome/*, float pFitness*/)
        {
            chromosome = pChromosome;
            /*fitness = pFitness;*/
            ComputeFitness();
        }

        private GeneticEntity()
        {

        }

        public int[] Chromosome
        { get { return chromosome; } }

        public float Fitness
        { get { return fitness; } }
  

        public virtual void ComputeFitness()
        {
            Debug.Log("Nada.");
        }

        protected void SetFitness(float pFitness)
        {
            fitness = pFitness;
        }
        public static int[] GenerateRandomChromosome(Vector2Int pMinMax, int pLength, int pRandomSeed)
        {            
            int[] chromosome = new int[pLength];
            for (int i = 0; i < chromosome.Length; i++)
            {
                chromosome[i] = Random.Range(pMinMax.x, pMinMax.y);
            }
            return chromosome;
        }

        public static void SeedRandom(int pRandomSeed)
        {
            Random.InitState(pRandomSeed);
        }
      
    }

}
