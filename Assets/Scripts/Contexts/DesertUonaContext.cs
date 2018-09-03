using Services;
using UnityEngine;
using Signals;
using View;

namespace Contexts
{
    public class DesertUonaContext : LevelContext
    {
        public DesertUonaContext() : base() { }
        public DesertUonaContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            #region CommandBinder
            commandBinder.Bind<StartSignal>()
                .Once();
            commandBinder.Bind<AttackSignal>();
            #endregion

            #region MediationBinder
            mediationBinder.Bind<DefaultSpawnerView>().To<DefaultSpawnerMediator>();
            mediationBinder.Bind<LazySpawnerView>().To<LazySpawnerMediator>();
            mediationBinder.Bind<PlayerView>().To<PlayerMediator>();
            mediationBinder.Bind<SkeletonView>().To<SkeletonMediator>();
            mediationBinder.Bind<KulakWeaponView>().To<KulakWeaponMediator>();
            #endregion
        }
    }
}