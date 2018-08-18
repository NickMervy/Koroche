using System.Linq;
using strange.extensions.command.impl;
using Services;
using UnityEngine;

namespace Controllers
{
    public class SpawnPlayerCommand : Command
    {
        [Inject] public DataService DataService { get; set; }
        [Inject] public SpawnService SpawnService { get; set; }

        public override void Execute()
        {
            var player = DataService.Prefabs.First(p => p.name == "Player");
            SpawnService.Spawn(player);
        }
    }
}