using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class LazySpawnerView : EventView
    {
        public event Action Spawn;

        private readonly List<GameObject> _prefabs = new List<GameObject>();

        public Transform Transform { get; private set; }
        public List<GameObject> Prefabs { get { return _prefabs; } } 

        protected override void Awake()
        {
            base.Awake();
            Transform = GetComponent<Transform>();
        }

        protected override void Start()
        {
            base.Start();
            OnSpawn();
        }

        protected virtual void OnSpawn()
        {
            var handler = Spawn;
            if (handler != null) handler();
        }
    }
}