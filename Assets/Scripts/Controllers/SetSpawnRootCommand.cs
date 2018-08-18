using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class SetSpawnRootCommand : Command
    {
        [Inject] public SpawnService SpawnService { get; set; }
        [Inject] public SpawnRootView SpawnRootView { get; set; }

        public override void Execute()
        {
            SpawnService.SpawnRoot = SpawnRootView.transform;
        }
    }
}