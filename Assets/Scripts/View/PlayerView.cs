using System;
using strange.extensions.context.impl;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class PlayerView : EventView
    {
        public event Action PlayerSpawn;

        protected override void Start()
        {
            base.Start();
            OnPlayerSpawn();
        }

        protected virtual void OnPlayerSpawn()
        {
            var handler = PlayerSpawn;
            if (handler != null) handler();
        }
    }
}