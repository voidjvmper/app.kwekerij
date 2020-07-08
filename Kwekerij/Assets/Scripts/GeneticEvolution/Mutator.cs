using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutator : MonoBehaviour
{
    protected float chanceToMutuate = float.MinValue;
    public Mutator(float pChanceToMutate = float.MinValue)
    {
        chanceToMutuate = pChanceToMutate;
    }


    private void DetermineChanceToMutate(int pChromosomeLength)
    {
        //Finds the number of places the chromosome contains (i.e. 1 for '9', 2 for '56', 3 for '740')
        int numberOfPlaces = pChromosomeLength.ToString().Length;
        //Converts length into a float between 0 and 1, to be used as a percentage
        float chanceAsFloat = pChromosomeLength * Mathf.Pow(0.1f, numberOfPlaces);
        chanceToMutuate = chanceToMutuate == float.MinValue ? chanceAsFloat : chanceToMutuate;
    }

    protected virtual void Mutate(ref int[] pChromosome)
    {
        for (int i = 0; i < pChromosome.Length; i++)
        {
            float roll = Random.Range(0.0f, 1.0f);
            pChromosome[i] = roll <= chanceToMutuate ? 1 : pChromosome[i];
        }
    }

}
