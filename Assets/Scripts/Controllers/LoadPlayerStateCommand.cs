using System.Linq;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class LoadPlayerStateCommand : Command
    {
        [Inject] public IStatesService StatesService { get; set; }
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            var guidState = StatesService.CurrentGameState
                .CharacterStates.First(c => c.Value.ModelId == "Player");
            PlayerView.Guid = guidState.Key;
            StatesService.PlayerState = guidState.Value;
        }
    }
}