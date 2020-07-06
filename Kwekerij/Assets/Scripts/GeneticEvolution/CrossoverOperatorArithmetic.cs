using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VUSSK_GeneticEvolution
{
    public class CrossoverOperatorArithmetic : CrossoverOperator
    {
        protected Vector2 childWeighting = new Vector2(0.5f, 0.5f);
        /// <summary>
        /// This is a base class for arithmetic function Crossover Operators and as such should not be instantiated.
        /// </summary>
        public CrossoverOperatorArithmetic(float pChildAWeighting = 0.5f, float pChildBWeighting = 0.5f)
        {
            childWeighting = new Vector2(Mathf.Clamp01(pChildAWeighting), Mathf.Clamp01(pChildBWeighting));
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// Returns the whole arithmetic average of two operands by a weighting.
        /// </summary>
        /// <param name="pGeneA"></param>
        /// <param name="pGeneB"></param>
        /// <param name="pAlpha"></param>
        /// <returns></returns>
        protected int DoArithmetic(int pGeneA, int pGeneB, float pAlpha)
        {
            //α.x + (1-α).y
            return Mathf.CeilToInt(pAlpha * pGeneA + (1 - pAlpha) * pGeneB);
        }
    }
}


