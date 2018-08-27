using Models;
using strange.extensions.mediation.impl;
using Signals;
using UnityEngine;

namespace View
{
    public class MenuMediator : TargetMediator<MenuView>
    {
        [Inject] public NewGameButtonClickSignal NewGameButtonClickSignal { get; set; }
        [Inject] public ContinueButtonClickSignal ContinueButtonClickSignal { get; set; }
        [Inject] public AppExitSignal AppExitSignal { get; set; }

        public override void OnRegister()
        {
            View.StartJourneyButtonClick += HandleNewGameButtonClick;
            View.ContinueButtonClick += HandleContinueButtonClick;
            View.ExitButtonClick += HandleExitButtonClick;
        }

        public override void OnRemove()
        {
            View.StartJourneyButtonClick -= HandleNewGameButtonClick;
            View.ContinueButtonClick -= HandleContinueButtonClick;
            View.ExitButtonClick -= HandleExitButtonClick;
        }

        private void HandleNewGameButtonClick()
        {
            NewGameButtonClickSignal.Dispatch();
        }

        private void HandleContinueButtonClick()
        {
            ContinueButtonClickSignal.Dispatch();
        }

        private void HandleExitButtonClick()
        {
            AppExitSignal.Dispatch();
        }

        private void HandleSetContinueButtonSignal(bool state)
        {
            View.SetContinueButton(state);
        }
    }
}