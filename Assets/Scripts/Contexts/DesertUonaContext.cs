using Services;
using UnityEngine;
using Signals;
using View;

namespace Contexts
{
    public class DesertUonaContext : GameContext
    {
        public DesertUonaContext() : base() { }
        public DesertUonaContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            #region CommandBinder
            commandBinder.Bind<StartSignal>()
                .Once();
            #endregion

            #region MediationBinder
            mediationBinder.Bind<SpawnersView>().To<SpawnersMediator>();
            mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
            mediationBinder.Bind<SkeletonView>().To<SkeletonMediator>();
            #endregion
        }
    }
}