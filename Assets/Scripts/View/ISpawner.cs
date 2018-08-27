using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public interface ISpawner
    {
        IList<GameObject> Prefabs { get; } 
        void Spawn();
    }
}