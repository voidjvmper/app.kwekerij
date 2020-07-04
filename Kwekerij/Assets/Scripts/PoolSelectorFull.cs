using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

/// <summary>
/// This Mating Pool Selector creates a mating pool comprised of the full supplied population.
/// </summary>
public class PoolSelectorFull : IMatingPoolSelector
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This Mating Pool Selector returns a pool composed of the full supplied population.
    /// </summary>
    /// <param name="pPopulation"></param>
    /// <param name="pSize"></param>
    /// <returns>List of GeneticEntity</returns>
    public List<GeneticEntity> SelectPool(List<GeneticEntity> pPopulation, int pSize)
    {
        return pPopulation;
    }
}
