using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VUSSK_GeneticEvolution;

public class Testbench : MonoBehaviour
{
    [Serializable] public enum CrossoverOperatorLoad { OnePoint, KPoint, Uniform, WholeArithmetic, SimpleArithmetic, SingleArithmetic, TOTAL };
    public enum MatingPoolSelectorLoad { Fittest, Full, Random, TOTAL };
    public enum BreedingPairSelectorLoad { AlphaA, EqualPrince, UnequalPrince, Equity, Fittest, NarrowRandom, Sequential, TOTAL };

    public enum MutatorLoad { BitFlip, Invert, Reset, Scramble, Swap, TOTAL };

    [SerializeField] private uint alleleLowerLimit;
    [SerializeField] private uint alleleUpperLimit;

    [SerializeField]
    private CrossoverOperatorLoad crossoverOperator;

    [SerializeField]
    private MatingPoolSelectorLoad matingPoolSelector;

    [SerializeField]
    private BreedingPairSelectorLoad breedingPairSelector;

    [SerializeField]
    private MutatorLoad mutator;

    [SerializeField]
    private uint targetFramerate;

    private ICrossoverOperator rtnCrossoverOperator;
    private IMatingPoolSelector rtnMatingPoolSelector;
    private IBreedingPairSelector rtnBreedingPairSelector;
    private IMutator rtnMutator;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = (int)targetFramerate;
    }

    public void SetCrossoverOperator(CrossoverOperatorLoad pCO)
    {
        crossoverOperator = pCO;
    }

    public void SetMatingPoolSelector(MatingPoolSelectorLoad pMPS)
    {
        matingPoolSelector = pMPS;
    }

    public void SetBreedingPairSelector(BreedingPairSelectorLoad pBPS)
    {
        breedingPairSelector = pBPS;
    }

    public void SetMutator(MutatorLoad pM)
    {
        mutator = pM;
    }

    public ICrossoverOperator CrossoverOperator
    { get { return GetUsedCrossoverOperator(); } }

    public IMatingPoolSelector MatingPoolSelector
    { get { return GetUsedMatingPoolSelector(); } }

    public IBreedingPairSelector BreedingPairSelector
    { get { return GetUsedBreedingPairSelector(); } }

    public IMutator Mutator
    { get { return GetUsedMutator(); } }
    
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

    public IMutator GetUsedMutator()
    {
        switch (mutator)
        {
            case MutatorLoad.BitFlip:
                rtnMutator = new MutatorBitFlip();
                break;
            case MutatorLoad.Invert:
                rtnMutator = new MutatorInvert();
                break;
            case MutatorLoad.Reset:
                rtnMutator = new MutatorReset();
                break;
            case MutatorLoad.Scramble:
                rtnMutator = new MutatorScramble();
                break;
            case MutatorLoad.Swap:
                rtnMutator = new MutatorSwap();
                break;
            default:
                rtnMutator = new MutatorReset();
                break;
        }
        return rtnMutator;
    }

    public uint AlleleLower
    {
        get { return alleleLowerLimit; }
    }

    public uint AlleleUpper
    {
        get { return alleleUpperLimit; }
    }
}
