using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MenuView : EventView
    {
        public event Action StartJourneyButtonClick;
        public event Action ContinueButtonClick;
        public event Action ExitButtonClick;

        [SerializeField] private Button _continueButton;

        public virtual void OnStartJourneyButtonClick()
        {
            var handler = StartJourneyButtonClick;
            if (handler != null) handler();
        }

        public virtual void OnContinueButtonClick()
        {
            var handler = ContinueButtonClick;
            if (handler != null) handler();
        }

        public virtual void OnExitClick()
        {
            var handler = ExitButtonClick;
            if (handler != null) handler();
        }

        public void SetContinueButton(bool state)
        {
            _continueButton.interactable = state;
        }
    }
}