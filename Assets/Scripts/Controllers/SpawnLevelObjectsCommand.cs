using strange.extensions.command.impl;
using View;

namespace Controllers
{
    public class SpawnLevelObjectsCommand : Command
    {
        [Inject] public SpawnersView SpawnersView { get; set; }

        public override void Execute()
        {
            SpawnersView.SpawnAll();
        }
    }
}