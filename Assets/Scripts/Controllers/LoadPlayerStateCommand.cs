using System.Linq;
using strange.extensions.command.impl;
using Services;

namespace Controllers
{
    public class LoadPlayerStateCommand : Command
    {
        [Inject] public IStatesService StatesService { get; set; }

        public override void Execute()
        {
            var state = StatesService.CurrentGameState
                .CharacterStates.First(c => c.Model.Id == "Player");
            StatesService.PlayerState = state;
        }
    }
}