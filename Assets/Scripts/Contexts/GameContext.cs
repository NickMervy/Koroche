using Controllers;
using Models;
using Signals;
using UnityEngine;

namespace Contexts
{
    public class GameContext : SignalContext
    {
        public GameContext() : base() { }
        public GameContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            #region CommandBinder

            //todo: use StatePattern
            var data = injectionBinder.GetInstance<GameStartData>();
            if (data.State == GameStartState.New)
            {
                commandBinder.Bind<SpawnersReadySignal>()
                    .To<SpawnAllCommand>()
                    .InSequence();
                commandBinder.Bind<StartPlayerSignal>()
                    .To<NewPlayerStateCommand>()
                    .To<AssignPlayerStateCommand>()
                    .Once();
            }
            else if (data.State == GameStartState.Continue)
            {
                commandBinder.Bind<SpawnersReadySignal>()
                    .To<FillLazySpawnListCommand>()
                    .To<SpawnLazyCommand>()
                    .InSequence()
                    .Once();
                commandBinder.Bind<StartPlayerSignal>()
                    .To<LoadPlayerStateCommand>()
                    .To<AssignPlayerStateCommand>()
                    .Once();
            }
            #endregion
        }
    }
}