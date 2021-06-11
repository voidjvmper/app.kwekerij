using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class Mutator : IMutator
    {
        protected float chanceToMutuate = float.MinValue;
        public Mutator(float pChanceToMutate = float.MinValue)
        {
            //Ensure the passed chance is constrained between 0 and 1
            chanceToMutuate = Mathf.Clamp01(pChanceToMutate);
        }

        public List<T> Mutate<T>(List<T> pPopulation) where T : GeneticEntity
        {
            //List<T> mutatedPopulation = new List<T>();
            for (int i = 0; i < pPopulation.Count; i++)
            {
                int[] mutatedChromosome = BeginMutationProcess(pPopulation[i]);

                //Overwrite the given population's chromosome with the mutated one
                for (int j = 0; j < pPopulation[i].Chromosome.Length; j++)
                {
                    pPopulation[i].Chromosome[j] = mutatedChromosome[j];
                }
                //mutatedPopulation.Add((T)System.Activator.CreateInstance(typeof(T), new object[] { mutatedChromosome }));
            }

            //return the original population with its new chromosome
            return pPopulation;
        }

        protected int[] BeginMutationProcess<T>(T pEntity) where T : GeneticEntity
        {
            int[] mutatedChromosome = pEntity.Chromosome;
            for (int i = 0; i < mutatedChromosome.Length; i++)
            {
                float roll = Random.Range(0.0f, 1.0f);
                if (roll <= DetermineChanceToMutate(mutatedChromosome.Length))
                {
                    mutatedChromosome = InternalMutate(pEntity);
                }
                //pChromosome[i] = roll <= DetermineChanceToMutate(pChromosome.Length) ? 1 : pChromosome[i];
            }
            return mutatedChromosome;
        }

        private float DetermineChanceToMutate(int pChromosomeLength)
        {
            float chanceOutput = float.MinValue;
            if (chanceToMutuate != float.MinValue)
            {
                chanceOutput = chanceToMutuate;
            }
            else
            {
                //Finds the length of numeric places the chromosome contains, singles, tens, thousands (i.e. 1 for '9', 2 for '56', 3 for '740', etc.)
                int numberOfPlaces = pChromosomeLength.ToString().Length;

                //Converts length into a float between 0 and 1, to be used as a percentage
                float chanceAsFloat = pChromosomeLength * Mathf.Pow(0.1f, numberOfPlaces);

                //Only use the chanceAsFloat as a backup in case no chanceToMutate was given
                chanceOutput = chanceToMutuate == float.MinValue ? chanceAsFloat : chanceToMutuate;
            }

            return chanceOutput;
        }



        protected virtual int[] InternalMutate<T>(T pEntity) where T : GeneticEntity
        {
            return pEntity.Chromosome;
        }

    }
}
