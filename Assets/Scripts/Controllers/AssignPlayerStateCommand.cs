using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class AssignPlayerStateCommand : Command
    {
        [Inject] public IStatesService StatesService { get; set; }
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            var state = StatesService.PlayerState;
            PlayerView.SetState(state);
        }
    }
}