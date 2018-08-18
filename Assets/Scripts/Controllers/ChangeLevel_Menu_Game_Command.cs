using Models;
using strange.extensions.command.impl;
using Signals;

namespace Controllers
{
    public class ChangeLevel_Menu_Game_Command : Command
    {
        [Inject] public ChangeLevelSignal ChangeLevelSignal { get; set; }

        public override void Execute()
        {
            ChangeLevelSignal.Dispatch(new ChangeLevelInfo
            {
                CallerScene = Constants.MenuScene,
                TargetScene = Constants.GameScene
            });
        }
    }
}