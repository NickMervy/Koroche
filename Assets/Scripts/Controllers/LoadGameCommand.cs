using System.IO;
using Models;
using strange.extensions.command.impl;
using Services;
using UnityEngine;

namespace Controllers
{
    public class LoadGameCommand : Command
    {
        [Inject] public IStatesService StatesService { get; set; }

        public override void Execute()
        {
            StatesService.CurrentGameState = StatesService.UserState.Saves[0];
        }
    }
}