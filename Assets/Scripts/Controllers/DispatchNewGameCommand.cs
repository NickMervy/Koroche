using System;
using System.Collections.Generic;
using Models;
using strange.extensions.command.impl;
using Services;
using Signals;

namespace Controllers
{
    public class DispatchNewGameCommand : Command
    {
        [Inject] public NewGameSignal NewGameSignal { get; set; }

        public override void Execute()
        {
            NewGameSignal.Dispatch(new ChangeLevelData
            {
                CallerScene = Constants.MenuScene,
                TargetScene = Constants.GameScene,
            });
        }
    }
}