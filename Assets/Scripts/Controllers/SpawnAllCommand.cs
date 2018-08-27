using strange.extensions.command.impl;
using View;

namespace Controllers
{
    public class SpawnAllCommand : Command
    {
        [Inject] public SpawnersView SpawnersView { get; set; }

        public override void Execute()
        {
            SpawnersView.SpawnAll();
        }

    }
}