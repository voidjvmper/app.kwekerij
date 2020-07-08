using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

namespace Shop.Events
{
    public class GenerationArgs<T> : EventArgs
    {
        public List<T> population;
        public float high;
        public float average;
        public int generationNumber;
        public GenerationArgs(List<T> pPopulation, float pHigh, float pAverage, int pGenerationNumber) 
        {
            population = pPopulation;
            high = pHigh;
            average = pAverage;
            generationNumber = pGenerationNumber;
        }
    }
}