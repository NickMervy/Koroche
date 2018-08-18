using Signals;

namespace View
{
    public class SpawnRootViewMediator : TargetMediator<SpawnRootView>
    {
        [Inject] public NewSpawnRootSignal NewSpawnRootSignal { get; set; }

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
            NewSpawnRootSignal.Dispatch(View);
        }
    }
}