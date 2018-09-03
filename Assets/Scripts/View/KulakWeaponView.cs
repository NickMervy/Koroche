using System;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class KulakWeaponView : EventView
    {
        public event Action<Collider2D> Hit;

        public int ParentId { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            ParentId = GetComponentInParent<UniqueId>().Id;
        }

        public void OnTriggerEnter2D(Collider2D col2D)
        {
            OnHit(col2D);
        }

        protected virtual void OnHit(Collider2D obj)
        {
            var handler = Hit;
            if (handler != null) handler(obj);
        }
    }
}