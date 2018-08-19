using Models;
using strange.extensions.command.impl;
using Services;

namespace Controllers
{
    public class LoadGameStateCommand : Command
    {
        [Inject] public StateService StateService { get; set; }

        public override void Execute()
        {
            StateService.LoadGameState();
        }
    }
}