using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Events
{
    public class SoilArgs: EventArgs
    {
        public Vector4 soilMakeup;
        public SoilArgs(Vector4 pSoilMakeup)
        {
            soilMakeup = pSoilMakeup;
        }
    }
}
