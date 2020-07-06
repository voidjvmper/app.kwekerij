using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shuffler
{ 
    /// <summary>
    /// Uses a lowest-highest modern Fisher-Yates algorithm to sort elements.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="pList"></param>
    public static void Shuffle<T>(ref List<T> pList)
    {
        for (int i = 0; i < pList.Count - 2; i++)
        {
            int rand = Random.Range(i, pList.Count);
            T temp = pList[i];
            pList[i] = pList[rand];
            pList[rand] = temp;
        }
    }
}
