using System;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Networking;

namespace Services
{
    public class DataService
    {
        [Inject(typeof(DataService))] public IDataLoader Loader { get; set; }

        public IEnumerable<CharacterModel> Characters { get; private set; }

        public void LoadPrefabs()
        {
            Loader.Load<PrefabsContainer>(Constants.PrefabsContainerPath, pc =>
            {
                Characters = pc.Characters;
                Debug.Log("Prefabs loaded");
            });
        }

        public void LoadPrefabs(Action callback)
        {
            Loader.Load<PrefabsContainer>(Constants.PrefabsContainerPath, pc =>
            {
                Characters = pc.Characters;
                Debug.Log("Prefabs loaded");
                callback();
            });
        }
    }
}