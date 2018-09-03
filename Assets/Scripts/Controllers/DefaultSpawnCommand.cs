using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class DefaultSpawnCommand : Command
    {
        [Inject] public DefaultSpawnerView DefaultSpawnerView { get; set; }
        [Inject] public SpawnService SpawnService { get; set; }

        public override void Execute()
        {
            var prefabs = DefaultSpawnerView.Prefabs;
            var parent = DefaultSpawnerView.Transform;

            foreach (var p in prefabs)
            {
                SpawnService.Spawn(p, parent);
            }
        }
    }
}