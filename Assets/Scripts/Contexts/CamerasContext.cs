using Signals;
using UnityEngine;
using View;

namespace Contexts
{
    public class CamerasContext : SignalContext
    {
        public CamerasContext() : base() { }
        public CamerasContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            #region CommandBinder
            commandBinder.Bind<StartSignal>().Once();
            #endregion

            #region MediationBinder
            mediationBinder.Bind<VirtualCamera2DView>()
                .To<VirtualCamera2DViewMediator>();
            #endregion
        }
    }
}