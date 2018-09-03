using Signals;
using UnityEngine;

namespace View
{
    public class VirtualCamera2DMediator : TargetMediator<VirtualCamera2DView>
    {
        [Inject] public StartPlayerSignal LocalPLayerSpawnSignal { get; set; }

        public override void OnRegister()
        {
            LocalPLayerSpawnSignal.AddListener(HandleLocalPlayerSpawnSignal);
        }

        public override void OnRemove()
        {
            LocalPLayerSpawnSignal.RemoveListener(HandleLocalPlayerSpawnSignal);
        }

        private void HandleLocalPlayerSpawnSignal(PlayerView playerView)
        {
            View.SetFollowTarget(playerView.gameObject);
        }
    }
}