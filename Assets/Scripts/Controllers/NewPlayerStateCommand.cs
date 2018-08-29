using System.Collections.Generic;
using System.Linq;
using Models;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class NewPlayerStateCommand : Command
    {
        [Inject] public GuidService GuidService { get; set; }
        [Inject] public DataService DataService { get; set; }
        [Inject] public IStatesService StatesService { get; set; }
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            var model = DataService.Characters.First(p => p.Id == "Player");
            var guid = GuidService.GenerateGuid().ToString();

            var state = new PlayerState
            {
                Health = model.Health,
                ModelId = model.Id,
                MoveSpeed = model.MoveSpeed,
                Position = PlayerView.transform.position
            };

            PlayerView.Guid = guid;
            StatesService.PlayerState = state;
            StatesService.CurrentGameState.CharacterStates.Add(guid, state);
        }
    }
}