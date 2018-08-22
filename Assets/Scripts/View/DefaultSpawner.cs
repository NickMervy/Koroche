using System.Collections.Generic;
using strange.extensions.mediation.impl;
using Services;
using UnityEngine;

namespace View
{
    public class DefaultSpawner : EventView, ISpawner
    {
        [SerializeField] private List<GameObject> _prefabs;

        public void Spawn()
        {
            foreach (var p in _prefabs)
            {
                Instantiate(p, transform.position, Quaternion.identity, transform);
            }
        }
    }
}