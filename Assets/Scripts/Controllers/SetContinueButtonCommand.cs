using Models;
using strange.extensions.command.impl;
using Services;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class SetContinueButtonCommand : Command
    {
        [Inject] public StateService StateService { get; set; }
        [Inject] public SetContinueButtonSignal SetContinueButtonSignal { get; set; }

        public override void Execute()
        {
            var state = StateService.HasSaves(Constants.GameStateKey);
            SetContinueButtonSignal.Dispatch(state);
        }
    }
}