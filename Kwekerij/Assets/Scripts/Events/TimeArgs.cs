using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Events
{
    public class TimeArgs : EventArgs
    {
        public float time;
        public TimeArgs(float pTime)
        {
            time = pTime;
        }
    }
}
