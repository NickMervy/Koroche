using Controllers;
using Signals;
using UnityEngine;

namespace Contexts
{
    public class LevelContext : SignalContext
    {
        public static ILevelBehaviour LevelBehaviour = new NewLevelBehaviour();

        public LevelContext() : base() { }
        public LevelContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            base.mapBindings();
            LevelBehaviour.MapBindings(this);

            #region CommandBinder
            commandBinder.Bind<AttackSignal>()
                .To<AttackCommand>()
                .Pooled();
            commandBinder.Bind<CharacterHealthUpdateSignal>();
            commandBinder.Bind<CharacterDeathSignal>();
            #endregion
        }
    }
}