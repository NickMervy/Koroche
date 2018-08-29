using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public class DataService
    {
        [Inject(typeof(DataService))] public ILoader Loader { get; set; }
        [Inject] public Constants Constants { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public IEnumerable<CharacterModel> Characters { get; private set; }

        public void LoadPrefabs()
        {
            Loader.Load<PrefabsContainer>(Constants.PrefabsContainerPath, pc =>
            {
                Characters = pc.Characters;
                Logger.Log("Prefabs loaded");
            });
        }

        public void LoadPrefabs(Action callback)
        {
            Loader.Load<PrefabsContainer>(Constants.PrefabsContainerPath, pc =>
            {
                Characters = pc.Characters;
                Logger.Log("Prefabs loaded");
                callback();
            });
        }
    }
}