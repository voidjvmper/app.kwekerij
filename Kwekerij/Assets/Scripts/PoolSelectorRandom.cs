using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VOSSK_GeneticEvolution
{
    public class PoolSelectorRandom : IMatingPoolSelector
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
            Shuffler.Shuffle(ref pPopulation);
            int size = (pSize <= pPopulation.Count && pSize > 0)? pSize : pPopulation.Count;

            //matingPool = pPopulation.OrderBy(a => Guid.NewGuid()).ToList();
            pPopulation.RemoveRange(size - 1, pPopulation.Count - size);
            return pPopulation;
        }
    }
}
