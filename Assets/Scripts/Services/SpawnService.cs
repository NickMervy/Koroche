using System.Collections.Generic;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Services
{
    public class SpawnService
    {
        public GameObject Spawn(GameObject obj, Vector3 position, Quaternion rotation, Transform parent)
        {
            return GameObject.Instantiate(obj, position, rotation, parent);
        }

        public GameObject Spawn(GameObject obj, Vector3 position, Quaternion rotation)
        {
            return GameObject.Instantiate(obj, position, rotation);
        }

        public GameObject Spawn(GameObject obj, Transform parent)
        {
            return GameObject.Instantiate(obj, parent);
        }
    }
}