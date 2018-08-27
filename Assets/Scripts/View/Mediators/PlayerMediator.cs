using Signals;
using UnityEngine;

namespace View
{
    public class PlayerMediator : TargetMediator<PlayerView>
    {
        [Inject] public StartPlayerSignal StartPlayerSignal { get; set; }

        public override void OnRegister()
        {
            View.PlayerStart += OnPlayerSpawn;
        }

        public override void OnRemove()
        {
            View.PlayerStart -= OnPlayerSpawn;
        }

        private void OnPlayerSpawn()
        {
            StartPlayerSignal.Dispatch(View);
        }
    }
}