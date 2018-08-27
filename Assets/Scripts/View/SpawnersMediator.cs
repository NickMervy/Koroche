using Signals;

namespace View
{
    public class SpawnersMediator : TargetMediator<SpawnersView>
    {
        [Inject] public SpawnersReadySignal SpawnersReadySignal { get; set; }

        public override void OnRegister()
        {
            View.SpawnersStart += HandleSpawnersStart;
        }

        public override void OnRemove()
        {
            View.SpawnersStart -= HandleSpawnersStart;
        }

        private void HandleSpawnersStart()
        {
            SpawnersReadySignal.Dispatch(View);
        }
    }
}