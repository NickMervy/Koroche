using Models;
using strange.extensions.command.impl;

namespace Controllers
{
    public class SetStartGameStateCommand : Command
    {
        [Inject] public GameStartData GameStartData { get; set; }
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }

        public override void Execute()
        {
            GameStartData.State = ChangeLevelData.GameStartState;
        }
    }
}