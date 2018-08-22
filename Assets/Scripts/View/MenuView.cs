using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class MenuView : EventView
    {
        public event Action SingleplayerButtonClick;
        public event Action CooperativeButtonClick;
        public event Action ExitButtonClick;

        [SerializeField] private Button _continueButton;

        public virtual void OnExitClick()
        {
            var handler = ExitButtonClick;
            if (handler != null) handler();
        }

        public virtual void OnSingleplayerClick()
        {
            var handler = SingleplayerButtonClick;
            if (handler != null) handler();
        }

        protected virtual void OnCooperativeButtonClick()
        {
            var handler = CooperativeButtonClick;
            if (handler != null) handler();
        }

        public void SetContinueButton(bool state)
        {
            _continueButton.interactable = state;
        }
    }
}