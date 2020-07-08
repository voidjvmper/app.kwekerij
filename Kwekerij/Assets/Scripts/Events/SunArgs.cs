using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Events
{
    public class SunArgs : EventArgs
    {
        public int sunHours;
        public int sunStrength;
        public SunArgs(int pSunHours, int pSunStrength)
        {
            sunHours = pSunHours;
            sunStrength = pSunStrength;
        }
    }
}
