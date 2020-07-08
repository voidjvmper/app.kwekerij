using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shop.Events;

public static class TimeLogger 
{
    private static int elapsed = 0;
    private static int start = 0;
    private static int end = 0;
    
    public static void LogStart()
    {
        start = Environment.TickCount;
        Debug.Log("Start: " + start);
    }

    public static void LogEnd()
    {
        end = Environment.TickCount;
        Debug.Log("End: " + end);
    }

   
    private static int CalculateElapsed()
    {
        elapsed = end - start;
        return elapsed;
    }
    public static int Elapsed
    {
        get { Debug.Log("Elapsed on calc: " + CalculateElapsed()); return CalculateElapsed(); }
    }
}
