using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class SpawnersView : EventView
    {
        public event Action StartEvent;
        private ISpawner[] _spawners;

        protected override void Awake()
        {
            _spawners = GetComponentsInChildren<ISpawner>();
        }

        protected override void Start()
        {
            OnStartEvent();
        }

        protected virtual void OnStartEvent()
        {
            var handler = StartEvent;
            if (handler != null) handler();
        }

        public void SpawnAll()
        {
            foreach (var s in _spawners)
            {
                s.Spawn();
            }
        }
    }
}