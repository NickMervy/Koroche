using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class LazySpawner : EventView, ISpawner
    {
        private readonly List<GameObject> _prefabs = new List<GameObject>();

        public IList<GameObject> Prefabs
        {
            get { return _prefabs; }
        }

        public void Spawn()
        {
            foreach (var p in _prefabs)
            {
                Instantiate(p, transform);
            }
        }
    }
}