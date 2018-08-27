using strange.extensions.command.impl;
using Services;

namespace Controllers
{
    public class SaveGameCommand : Command
    {
        [Inject] public IStatesService StatesService { get; set; }

        public override void Execute()
        {
            StatesService.Save();
        }
    }
}