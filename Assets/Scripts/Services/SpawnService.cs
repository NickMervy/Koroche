using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services
{
    public class SpawnService
    {
        public Transform SpawnRoot { get; set; }

        public void Spawn(GameObject prefab)
        {
            try
            {
                if(prefab == null)
                    throw new NullReferenceException("No prefab to spawn");
                if(SpawnRoot == null)
                    throw new NullReferenceException("SpawnRoot is not set");
                Object.Instantiate(prefab, SpawnRoot);
            }

            catch (NullReferenceException)
            {
                throw;
            }
        }
    }
}