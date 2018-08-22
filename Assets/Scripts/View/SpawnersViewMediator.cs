using Signals;

namespace View
{
    public class SpawnersViewMediator : TargetMediator<SpawnersView>
    {
        [Inject] public SpawnersReadySignal SpawnersReadySignal { get; set; }

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
            SpawnersReadySignal.Dispatch(View);
        }
    }
}