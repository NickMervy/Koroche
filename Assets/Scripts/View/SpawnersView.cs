using System;
using System.Collections.Generic;
using System.Linq;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class SpawnersView : EventView
    {
        public event Action SpawnersStart;

        private ISpawner[] _spawners;

        public IEnumerable<ISpawner> Spawners
        {
            get
            {
                _spawners = _spawners ?? GetComponentsInChildren<ISpawner>();
                return _spawners;
            }   
        }

        public ISpawner LazySpawner
        {
            get
            {
                return Spawners.First(s => s is LazySpawner);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            _spawners = _spawners ?? GetComponentsInChildren<ISpawner>();
        }

        protected override void Start()
        {
            base.Start();
            OnSpawnersStart();
        }

        public void SpawnAll()
        {
            foreach (var s in Spawners)
            {
                s.Spawn();
            }
        }

        public void SpawnLazy()
        {
            LazySpawner.Spawn();
        }

        protected virtual void OnSpawnersStart()
        {
            var handler = SpawnersStart;
            if (handler != null) handler();
        }
    }
}