using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

public class Testbench : MonoBehaviour
{
    [Serializable] public enum CrossoverOperatorLoad { OnePoint, KPoint, Uniform, WholeArithmetic, SimpleArithmetic, SingleArithmetic };
    public enum MatingPoolSelectorLoad { Fittest, Full, Random };
    public enum BreedingPairSelectorLoad { AlphaA, EqualPrince, UnequalPrince, Equity, Fittest, NarrowRandom, Sequential };

    [SerializeField]
    private CrossoverOperatorLoad crossoverOperator;

    [SerializeField]
    private MatingPoolSelectorLoad matingPoolSelector;

    [SerializeField]
    private BreedingPairSelectorLoad breedingPairSelector;

    private ICrossoverOperator rtnCrossoverOperator;
    private IMatingPoolSelector rtnMatingPoolSelector;
    private IBreedingPairSelector rtnBreedingPairSelector;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ICrossoverOperator CrossoverOperator
    { get { return GetUsedCrossoverOperator(); } }

    public IMatingPoolSelector MatingPoolSelector
    { get { return GetUsedMatingPoolSelector(); } }

    public IBreedingPairSelector BreedingPairSelector
    { get { return GetUsedBreedingPairSelector(); } }

    
    public ICrossoverOperator GetUsedCrossoverOperator()
    {
        switch (crossoverOperator)
        {
            case CrossoverOperatorLoad.OnePoint:
                rtnCrossoverOperator = new CrossoverOperatorOnePoint();
                break;
            case CrossoverOperatorLoad.KPoint:
                rtnCrossoverOperator = new CrossoverOperatorKPoint();
                break;
            case CrossoverOperatorLoad.Uniform:
                rtnCrossoverOperator = new CrossoverOperatorUniform();
                break;
            case CrossoverOperatorLoad.WholeArithmetic:
                rtnCrossoverOperator = new CrossoverOperatorWholeArithmetic();
                break;
            case CrossoverOperatorLoad.SimpleArithmetic:
                rtnCrossoverOperator = new CrossoverOperatorSimpleArithmetic();
                break;
            case CrossoverOperatorLoad.SingleArithmetic:
                rtnCrossoverOperator = new CrossoverOperatorSingleArithmetic();
                break;
            default:
                rtnCrossoverOperator = new CrossoverOperatorOnePoint();
                break;
        }
        return rtnCrossoverOperator;
    }

    public IMatingPoolSelector GetUsedMatingPoolSelector()
    {
        switch (matingPoolSelector)
        {
            case MatingPoolSelectorLoad.Fittest:
                rtnMatingPoolSelector = new PoolSelectorFittest();
                break;
            case MatingPoolSelectorLoad.Full:
                rtnMatingPoolSelector = new PoolSelectorFull();
                break;
            case MatingPoolSelectorLoad.Random:
                rtnMatingPoolSelector = new PoolSelectorRandom();
                break;
            default:
                rtnMatingPoolSelector = new PoolSelectorFull();
                break;
        }
        return rtnMatingPoolSelector;
    }

    public IBreedingPairSelector GetUsedBreedingPairSelector()
    {
        switch (breedingPairSelector)
        {
            case BreedingPairSelectorLoad.AlphaA:
                rtnBreedingPairSelector = new PairSelectorAlphaA();
                break;
            case BreedingPairSelectorLoad.EqualPrince:
                rtnBreedingPairSelector = new PairSelectorEqualPrince();
                break;
            case BreedingPairSelectorLoad.UnequalPrince:
                rtnBreedingPairSelector = new PairSelectorUnequalPrince();
                break;
            case BreedingPairSelectorLoad.Equity:
                rtnBreedingPairSelector = new PairSelectorEquity();
                break;
            case BreedingPairSelectorLoad.Fittest:
                rtnBreedingPairSelector = new PairSelectorFittest();
                break;
            case BreedingPairSelectorLoad.NarrowRandom:
                rtnBreedingPairSelector = new PairSelectorNarrowRandom();
                break;
            case BreedingPairSelectorLoad.Sequential:
                rtnBreedingPairSelector = new PairSelectorSequential();
                break;
            default:
                rtnBreedingPairSelector = new PairSelectorSequential();
                break;
        }
        return rtnBreedingPairSelector;
    }
}
