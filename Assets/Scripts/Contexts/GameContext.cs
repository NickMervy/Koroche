using Controllers;
using UnityEngine;
using Signals;
using View;

namespace Contexts
{
    public class GameContext : SignalContext
    {
        public GameContext() : base() { }
        public GameContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            commandBinder.Bind<StartSignal>()
                .To<AddUISceneCommand>()
                .Once();

            commandBinder.Bind<SpawnersReadySignal>()
                .To<SpawnLevelObjectsCommand>();
            commandBinder.Bind<StartPlayerSignal>()
                .To<InitPlayerCommand>();

            mediationBinder.Bind<SpawnersView>().To<SpawnersViewMediator>();
            mediationBinder.Bind<PlayerView>().To<PlayerViewMediator>();
            mediationBinder.Bind<RoomView>().To<RoomViewMediator>();
        }
    }
}