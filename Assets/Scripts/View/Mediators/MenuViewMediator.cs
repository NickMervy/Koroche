using Models;
using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

namespace View
{
    public class MenuViewMediator : TargetMediator<MenuView>
    {
        [Inject] public StartJourneySignal StartJourneySignal { get; set; }
        [Inject] public AppExitSignal AppExitSignal { get; set; }

        public override void OnRegister()
        {
            View.SingleplayerButtonClick += HandleSingleplayerButtonClick;
            View.ExitButtonClick += HandleExitButtonClick;
        }

        public override void OnRemove()
        {
            View.SingleplayerButtonClick -= HandleSingleplayerButtonClick;
            View.ExitButtonClick -= HandleExitButtonClick;
        }

        private void HandleSingleplayerButtonClick()
        {
            StartJourneySignal.Dispatch();
        }

        private void HandleExitButtonClick()
        {
            AppExitSignal.Dispatch();
        }
    }
}