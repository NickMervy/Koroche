using Signals;
using UnityEngine;

namespace View
{
    public class PlayerViewMediator : TargetMediator<PlayerView>
    {
        [Inject] public StartPlayerSignal PlayerSpawnSignal { get; set; }

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
            PlayerSpawnSignal.Dispatch(View);
        }
    }
}