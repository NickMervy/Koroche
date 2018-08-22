using Signals;
using UnityEngine;

namespace View
{
    public class PlayerViewMediator : TargetMediator<PlayerView>
    {
        [Inject] public StartPlayerSignal StartPlayerSignal { get; set; }

        public override void OnRegister()
        {
            View.PlayerSpawn += OnPlayerSpawn;
        }

        public override void OnRemove()
        {
            View.PlayerSpawn -= OnPlayerSpawn;
        }

        private void OnPlayerSpawn()
        {
            StartPlayerSignal.Dispatch(View);
        }
    }
}