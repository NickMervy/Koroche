using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class SetPlayerStateCommand : Command
    {
        [Inject] public StatesService StatesService { get; set; }
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            var id = PlayerView.Id;
            var state = StatesService.GetState(id);

            PlayerView.SetState(state);
        }
    }
}