
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop.Events
{
    public class EventProcessor : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            EventQueue.Update();
        }
    }
}


