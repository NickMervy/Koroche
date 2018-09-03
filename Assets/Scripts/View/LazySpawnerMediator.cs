using Signals;

namespace View
{
    public class LazySpawnerMediator : TargetMediator<LazySpawnerView>
    {
        [Inject]
        public LazySpawnerSignal LazySpawnerSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.Spawn += HandleSpawnerAwake;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.Spawn -= HandleSpawnerAwake;
        }

        private void HandleSpawnerAwake()
        {
            LazySpawnerSignal.Dispatch(View);
        }
    }
}