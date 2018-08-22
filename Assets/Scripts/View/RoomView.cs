using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class RoomView : EventView
    {
        public event Action StartEvent;

        public Collider2D Edges;

        protected override void Start()
        {
            base.Start();
            OnStart();
        }

        protected virtual void OnStart()
        {
            var handler = StartEvent;
            if (handler != null) handler();
        }
    }
}