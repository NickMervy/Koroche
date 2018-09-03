using strange.extensions.command.impl;
using Services;

namespace Controllers
{
    public class LoadSavesCommand : Command
    {
        [Inject] public StatesService StatesService { get; set; }

        public override void Execute()
        {
            StatesService.Load();
        }
    }
}