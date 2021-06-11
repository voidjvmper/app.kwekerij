using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class GeneticEntity 
    {
        //Theoretically this should be subclassed into a int[] specific encoded entity, but that's out of scope for now
        private int[] chromosome;
        private Vector2Int acceptedAlleleRange = Vector2Int.zero;
        protected float fitness;

        public GeneticEntity(int[] pChromosome, Vector2Int pAcceptedAlleleRange /*, float pFitness*/)
        {
            chromosome = pChromosome;
            acceptedAlleleRange = pAcceptedAlleleRange;
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

        public Vector2Int AlleleRange
        { get { return acceptedAlleleRange; } }

        public float AlleleLowerLimit
        { get { return acceptedAlleleRange.x; } }

        public float AlleleUpperLimit
        { get { return acceptedAlleleRange.y; } }


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
