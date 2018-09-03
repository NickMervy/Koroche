using System.Collections.Generic;
using Models;
using Signals;
using UnityEngine;

namespace View
{
    public class PlayerMediator : TargetMediator<PlayerView>
    {
        [Inject] public StartPlayerSignal StartPlayerSignal { get; set; }
        [Inject] public CharacterHealthUpdateSignal CharacterUpdateStateSignal { get; set; }

        public override void OnRegister()
        {
            View.PlayerStart += HandlePlayerSpawn;
            CharacterUpdateStateSignal.AddListener(HandleCharacterHealthUpdateSignal);
        }

        public override void OnRemove()
        {
            View.PlayerStart -= HandlePlayerSpawn;
            CharacterUpdateStateSignal.RemoveListener(HandleCharacterHealthUpdateSignal);
        }

        private void HandlePlayerSpawn()
        {
            StartPlayerSignal.Dispatch(View);
        }

        private void HandleCharacterHealthUpdateSignal(int key, ICharacterState state)
        {
            if (key != View.Id)
                return;

            //smth...
        }
    }
}