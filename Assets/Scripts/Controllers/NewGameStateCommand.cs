using strange.extensions.command.impl;
using Services;
using UniRx;

namespace Controllers
{
    public class NewGameStateCommand : Command
    {
        [Inject] public StateService StateService { get; set; }

        public override void Execute()
        {
            StateService.NewGameState();
        }
    }
}