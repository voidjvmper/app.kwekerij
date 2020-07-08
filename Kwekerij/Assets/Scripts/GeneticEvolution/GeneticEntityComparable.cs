using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

public class GeneticEntityComparable : IComparer<GeneticEntity>
{
 

    public int Compare(GeneticEntity gA, GeneticEntity gB)
    {
        int output = int.MaxValue;

        if (gA.Fitness > gB.Fitness)
        {
            output = -1;
        }

        if (gA.Fitness < gB.Fitness)
        {
            output = 1;
        }

        if (gA.Fitness == gB.Fitness)
        {
            output = 0;
        }

        return output;
    }
}
