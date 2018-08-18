using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class SpawnRootView : EventView
    {
        public event Action StartEvent;

        protected override void Start()
        {
            OnStartEvent();
        }

        protected virtual void OnStartEvent()
        {
            var handler = StartEvent;
            if (handler != null) handler();
        }
    }
}