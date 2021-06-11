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
        public int testIterations;
        public GenerationArgs(List<T> pPopulation, float pHigh, float pAverage, int pGenerationNumber, int pTestIterations = 0) 
        {
            population = pPopulation;
            high = pHigh;
            average = pAverage;
            generationNumber = pGenerationNumber;
            testIterations = pTestIterations;
        }
    }
}