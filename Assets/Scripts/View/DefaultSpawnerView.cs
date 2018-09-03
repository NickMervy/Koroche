using System;
using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class DefaultSpawnerView : EventView
    {
        public event Action Spawn;

        [SerializeField] private List<GameObject> _prefabs;

        public Transform Transform { get; private set; }
        public IList<GameObject> Prefabs { get { return _prefabs; } }

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