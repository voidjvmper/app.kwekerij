using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class GeneticEntity : IComparer
    {
        private int[] chromosome;
        protected float fitness;

        public GeneticEntity(int[] pChromosome, float pFitness)
        {
            chromosome = pChromosome;
            fitness = pFitness;
        }

        private GeneticEntity()
        {

        }

        public int[] Chromosome
        { get { return chromosome; } }

        public float Fitness
        { get { return fitness; } }
        
        public static IComparer<GeneticEntity> CompareFitness()
        {
            return (IComparer<GeneticEntity>)new GeneticEntity();
        }

        public virtual void ComputeFitness()
        {

        }

        protected void UpdateFitness(float pFitness)
        {
            fitness = pFitness;
        }
        public static int[] GenerateRandomChromosome(Vector2Int pMinMax, int pLength, int pRandomSeed)
        {
            Random.InitState(pRandomSeed);
            int[] chromosome = new int[pLength];
            for (int i = 0; i < chromosome.Length; i++)
            {
                chromosome[i] = Random.Range(pMinMax.x, pMinMax.y);
            }
            return chromosome;
        }

        public int Compare(object a, object b)
        {
            int output = int.MaxValue;

            GeneticEntity gA = (GeneticEntity)a;
            GeneticEntity gB = (GeneticEntity)b;
            if (gA.Fitness > gB.Fitness)
            {
                output = 1;
            }

            if (gA.Fitness < gB.Fitness)
            {
                output = -1;
            }

            if (gA.Fitness == gB.Fitness)
            {
                output = 0;
            }

            return output;
        }
    }

}
