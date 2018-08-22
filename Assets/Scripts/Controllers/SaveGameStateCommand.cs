using strange.extensions.command.impl;
using Services;

namespace Controllers
{
    public class SaveGameStateCommand : Command
    {
        [Inject] public StateService StateService { get; set; }

        public override void Execute()
        {
            StateService.SaveGameState();
        }
    }
}