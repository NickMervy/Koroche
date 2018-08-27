using strange.extensions.command.impl;
using View;

namespace Controllers
{
    public class SpawnLazyCommand : Command
    {
        [Inject] public SpawnersView SpawnersView { get; set; }

        public override void Execute()
        {
            SpawnersView.SpawnLazy();
        }
    }
}