using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

namespace Shop.Events
{
    public class GenerationArgs : EventArgs
    {
        public List<GeneticEntity> population;
        public float high;
        public float average;
        public GenerationArgs(List<GeneticEntity> pPopulation, float pHigh, float pAverage)
        {
            population = pPopulation;
            high = pHigh;
            average = pAverage;
        }
    }
}