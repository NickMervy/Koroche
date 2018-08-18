using Signals;
using UnityEditor;

namespace View
{
    public class RoomViewMediator : TargetMediator<RoomView>
    {
        [Inject] public AttachRoomEdgesSignal AttachRoomEdgesSignal { get; set; }

        public override void OnRegister()
        {
            View.StartEvent += HandleStartEvent;
        }

        public override void OnRemove()
        {
            View.StartEvent -= HandleStartEvent;
        }

        private void HandleStartEvent()
        {
            AttachRoomEdgesSignal.Dispatch(View.Edges);
        }
    }
}