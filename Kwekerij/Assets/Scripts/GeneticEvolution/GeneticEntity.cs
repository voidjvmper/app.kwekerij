using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class GeneticEntity : IComparer
    {
        private int[] chromosome;
        private float fitness;

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
