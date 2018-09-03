using Models;
using strange.extensions.command.impl;
using Services;

namespace Controllers
{
    public class NewGameStateCommand : Command
    {
        [Inject] public StatesService StatesService { get; set; }

        public override void Execute()
        {
            var gameState = new GameState();
            StatesService.CurrentGameState = gameState;
            StatesService.UserState.Saves.Add(gameState);
        }
    }
}