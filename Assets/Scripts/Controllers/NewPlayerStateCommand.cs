using System.Linq;
using Models;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class NewPlayerStateCommand : Command
    {
        [Inject] public DataService DataService { get; set; }
        [Inject] public IStatesService StatesService { get; set; }
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            var model = DataService.Characters.First(p => p.Id == "Player");
            var state = new CharacterState
            {
                Health = model.Health,
                Model = model,
                Position = PlayerView.transform.position
            };

            StatesService.CurrentGameState.CharacterStates.Add(state);
            StatesService.PlayerState = state;
        }
    }
}