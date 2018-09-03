using Signals;

namespace View
{
    public class DefaultSpawnerMediator : TargetMediator<DefaultSpawnerView>
    {
        [Inject] public DefaultSpawnerSignal DefaultSpawnerSignal { get; set; }

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
            DefaultSpawnerSignal.Dispatch(View);
        }
    }
}