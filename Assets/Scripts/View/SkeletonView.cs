using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    class SkeletonView : EventView
    {
        public event Action<Collider2D> TriggerEnter2D;

        private void OnTriggerEnter2D(Collider2D col2D)
        {
            var handler = TriggerEnter2D;
            if (handler != null) handler(col2D);
        }
    }
}