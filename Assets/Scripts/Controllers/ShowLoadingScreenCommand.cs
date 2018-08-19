using strange.extensions.command.impl;
using Signals;
using View;

namespace Controllers
{
    public class ShowLoadingScreenCommand : Command
    {
        [Inject] public ShowLoadingScreenSignal ShowLoadingScreenSignal { get; set; }

        public override void Execute()
        {
            ShowLoadingScreenSignal.Dispatch();
        }
    }
}