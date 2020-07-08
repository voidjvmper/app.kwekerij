using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Events
{
    public class PatchArgs : EventArgs
    {
        public int sunlightHours;
        public int sunlightStrength;
        public PatchArgs(int pHours, int pStrength)
        {
            sunlightHours = pHours;
            sunlightStrength = pStrength;            
        }
    }
}