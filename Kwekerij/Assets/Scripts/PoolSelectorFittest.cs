using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TimSort;
using UnityEngine;

namespace VOSSK_GeneticEvolution
{
    public class PoolSelectorFittest : IMatingPoolSelector
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public List<GeneticEntity> Select(List<GeneticEntity> pPopulation, int pSize)
        {
            List<GeneticEntity> matingPool = new List<GeneticEntity>();
            for (int i = 0; i < pPopulation.Count; i++)
            {
                
                TimSort<GeneticEntity>.sort(matingPool.ToArray(), GeneticEntity.CompareFitness());
                
            }
            
            return matingPool;
        }

    }
}