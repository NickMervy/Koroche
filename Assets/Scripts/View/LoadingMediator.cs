using Signals;

namespace View
{
    public class LoadingMediator : TargetMediator<LoadingView>
    {
        [Inject] public ShowLoadingScreenSignal ShowLoadingScreenSignal { get; set; }
        [Inject] public HideLoadingScreenSignal HideLoadingScreenSignal { get; set; }

        public override void OnRegister()
        {
            ShowLoadingScreenSignal.AddListener(HandleShowLoadingScreenSignal);
            HideLoadingScreenSignal.AddListener(HandleHideLoadingScreenSignal);
        }

        public override void OnRemove()
        {
            ShowLoadingScreenSignal.RemoveListener(HandleShowLoadingScreenSignal);
            HideLoadingScreenSignal.RemoveListener(HandleHideLoadingScreenSignal);
        }

        public void HandleShowLoadingScreenSignal()
        {
            View.ShowLoadingScreen();
        }

        public void HandleHideLoadingScreenSignal()
        {
            View.HideLoadingScreen();
        }
    }
}