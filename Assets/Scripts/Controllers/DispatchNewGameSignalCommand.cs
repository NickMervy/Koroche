using System;
using System.Collections.Generic;
using Contexts;
using Models;
using strange.extensions.command.impl;
using Services;
using Signals;

namespace Controllers
{
    public class DispatchNewGameSignalCommand : Command
    {
        [Inject] public NewGameSignal NewGameSignal { get; set; }
        [Inject] public Constants Constants { get; set; }

        public override void Execute()
        {
            NewGameSignal.Dispatch(new ChangeLevelData
            {
                CallerScene = Constants.MenuScene,
                TargetScene = Constants.DesertUona,
                LevelBehaviour = new NewLevelBehaviour()
            });
        }
    }
}