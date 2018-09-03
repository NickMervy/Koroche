using Contexts;
using Models;
using strange.extensions.command.impl;
using Signals;

namespace Controllers
{
    public class DispatchContinueSignalCommand : Command
    {
        [Inject] public ContinueGameSignal NewGameSignal { get; set; }
        [Inject] public Constants Constants { get; set; }

        public override void Execute()
        {
            NewGameSignal.Dispatch(new ChangeLevelData
            {
                CallerScene = Constants.MenuScene,
                TargetScene = Constants.DesertUona,
                LevelBehaviour = new ContinueLevelBehaviour()
            });
        }
    }
}