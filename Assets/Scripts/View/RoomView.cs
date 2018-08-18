using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class RoomView : EventView
    {
        public event Action StartEvent;

        public Grid Grid;
        public Collider2D Edges;

        protected override void Start()
        {
            base.Start();
            OnOnStart();
        }

        protected virtual void OnOnStart()
        {
            var handler = StartEvent;
            if (handler != null) handler();
        }
    }
}