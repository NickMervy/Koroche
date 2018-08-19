using Models;
using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

namespace View
{
    public class MenuViewMediator : TargetMediator<MenuView>
    {
        [Inject] public NewGameButtonClickSignal NewGameButtonClickSignal { get; set; }
        [Inject] public AppExitSignal AppExitSignal { get; set; }

        public override void OnRegister()
        {
            View.SingleplayerButtonClick += HandleNewGameButtonClick;
            View.ExitButtonClick += HandleExitButtonClick;
        }

        public override void OnRemove()
        {
            View.SingleplayerButtonClick -= HandleNewGameButtonClick;
            View.ExitButtonClick -= HandleExitButtonClick;
        }

        private void HandleNewGameButtonClick()
        {
            NewGameButtonClickSignal.Dispatch();
        }

        private void HandleExitButtonClick()
        {
            AppExitSignal.Dispatch();
        }
    }
}