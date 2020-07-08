using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Decimal
{
    public static float RoundToFactorOf(float pValue, float pDecimalAccuracy)
    { 
        float decimalPoint =  Mathf.Pow(10.0f, pDecimalAccuracy);
        return Mathf.Round(pValue * decimalPoint) / decimalPoint;
    }
}
