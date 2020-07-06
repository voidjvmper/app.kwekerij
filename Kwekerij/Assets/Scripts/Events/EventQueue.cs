using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Shop.Events
{
    public static class EventQueue
    {
        public enum EventType { Soil_Update,
                                Patch_Select,
                                Patch_Update,
                                Plot_Start,
                                Plot_End };

        //Event List
        public static event EventHandler SoilUpdateEvent;
        public static event EventHandler PatchSelectEvent;

        public static event EventHandler PatchUpdateEvent;
        public static event EventHandler PlotStartEvent;
        public static event EventHandler PlotEndEvent;

        private static Dictionary<EventType, EventHandler> typeHandlerPair = new Dictionary<EventType, EventHandler>();

        private static bool initialised = false;

        private const int MAX_QUEUE_SIZE = 16;
        private static int queueHead = 0;
        private static int queueTail = 0;

        private static EventDetails[] pendingEvents;

        private struct EventDetails
        {
            private object sender;
            private EventArgs args;
            private EventType eventType;

            public object Sender
            {
                get { return sender; }
                set { sender = value; }
            }

            public EventArgs Args
            {
                get { return args; }
                set { args = value; }
            }

            public EventType EventTypes
            {
                get { return eventType; }
                set { eventType = value; }
            }


        }

        public static void Initialise()
        {
            InitialisationSafeguard();
        }
        private static void InitialisePairings()
        {
            typeHandlerPair.Add(EventType.Soil_Update, SoilUpdateEvent);
            typeHandlerPair.Add(EventType.Patch_Select, PatchSelectEvent);
            typeHandlerPair.Add(EventType.Patch_Update, PatchUpdateEvent);

            typeHandlerPair.Add(EventType.Plot_Start, PlotStartEvent);
            typeHandlerPair.Add(EventType.Plot_End, PlotEndEvent);
        }

        private static void InitialiseQueue()
        {
            pendingEvents = new EventDetails[MAX_QUEUE_SIZE];
        }

        private static void InitialisationSafeguard()
        {
            if (!initialised)
            {
                InitialisePairings();
                InitialiseQueue();
            }
            initialised = true;
        }

        public static void QueueEvent(EventType pType, object sender, EventArgs e)
        {
            InitialisationSafeguard();
            if ((queueTail + 1) % MAX_QUEUE_SIZE != queueHead)
            {
                //
                pendingEvents[queueTail].EventTypes = pType;
                pendingEvents[queueTail].Sender = sender;
                pendingEvents[queueTail].Args = e;

                queueTail = (queueTail + 1) % MAX_QUEUE_SIZE;
            }
    
        }

        public static void Subscribe(EventType pType, EventHandler pHandler)
        {
            InitialisationSafeguard();
            typeHandlerPair[pType] += pHandler;
        }

        public static void Update()
        {
            if (queueHead == queueTail) { return; }
            EventDetails current = pendingEvents[queueHead];
            typeHandlerPair[current.EventTypes]?.Invoke(current.Sender, current.Args);
            Debug.Log("Event Processed, Type: " + current.EventTypes.ToString());
            queueHead = (queueHead + 1) % MAX_QUEUE_SIZE;
        }

        public static int QueueHead
        {
            get { return queueHead; }
        }

        public static int QueueTail
        {
            get { return queueHead; }
        }

        public static int MaximumQueueSize
        {
            get { return MAX_QUEUE_SIZE; }
        }

    }
}
