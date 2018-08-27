using strange.extensions.command.impl;
using Signals;
using View;

namespace Controllers
{
    public class HideLoadingScreenCommand : Command
    {
        [Inject] public HideLoadingScreenSignal HideLoadingScreenSignal { get; set; }

        public override void Execute()
        {
            HideLoadingScreenSignal.Dispatch();
        }
    }
}