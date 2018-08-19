using Signals;
using UnityEngine;

namespace View
{
    public class VirtualCamera2DViewMediator : TargetMediator<VirtualCamera2DView>
    {
        [Inject] public AttachRoomEdgesSignal AttachRoomEdgesSignal { get; set; }
        [Inject] public StartPlayerSignal LocalPLayerSpawnSignal { get; set; }

        public override void OnRegister()
        {
            AttachRoomEdgesSignal.AddListener(HandleAttachRoomEdgesSignal);
            LocalPLayerSpawnSignal.AddListener(HandleLocalPlayerSpawnSignal);
        }

        public override void OnRemove()
        {
            AttachRoomEdgesSignal.RemoveListener(HandleAttachRoomEdgesSignal);
            LocalPLayerSpawnSignal.RemoveListener(HandleLocalPlayerSpawnSignal);
        }

        private void HandleAttachRoomEdgesSignal(Collider2D collder2D)
        {
            View.SetBounders(collder2D);
        }

        private void HandleLocalPlayerSpawnSignal(PlayerView playerView)
        {
            View.SetFollowTarget(playerView.gameObject);
        }
    }
}