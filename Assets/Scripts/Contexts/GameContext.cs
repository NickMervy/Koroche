using Controllers;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;
using Signals;
using strange.extensions.context.impl;
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

            commandBinder.Bind<NewSpawnRootSignal>()
                .To<SetSpawnRootCommand>()
                .To<SpawnPlayerCommand>();

            mediationBinder.Bind<SpawnRootView>().To<SpawnRootViewMediator>();
            mediationBinder.Bind<PlayerView>().To<PlayerViewMediator>();
            mediationBinder.Bind<RoomView>().To<RoomViewMediator>();
        }
    }
}