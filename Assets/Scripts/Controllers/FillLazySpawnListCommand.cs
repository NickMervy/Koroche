using System;
using System.Linq;
using strange.extensions.command.impl;
using Services;
using UnityEngine;
using View;
using Object = UnityEngine.Object;

namespace Controllers
{
    public class FillLazySpawnListCommand : Command
    {
        [Inject] public DataService DataService { get; set; }
        [Inject] public IStatesService StatesService { get; set; }
        [Inject] public SpawnersView SpawnersView { get; set; }

        public override void Execute()
        {
            var characterStates = StatesService.CurrentGameState.CharacterStates;
            var characterModels = DataService.Characters;
            foreach (var cs in characterStates)
            {
                var prefab = characterModels.First(cm => cs.Value.ModelId == cm.Id).Prefab;
                SpawnersView.LazySpawner.Prefabs.Add(prefab);
            }
        }
    }
}