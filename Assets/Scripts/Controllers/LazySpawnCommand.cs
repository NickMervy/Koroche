using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class LazySpawnCommand : Command
    {
        [Inject] public LazySpawnerView LazySpawnerView { get; set; }
        [Inject] public SpawnService SpawnService { get; set; }

        public override void Execute()
        {
            var prefabs = LazySpawnerView.Prefabs;
            var parent = LazySpawnerView.Transform;

            foreach (var p in prefabs)
            {
                SpawnService.Spawn(p, parent);
            }
        }
    }
}