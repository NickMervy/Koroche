using Controllers;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using Services;
using Signals;
using UnityEngine;

namespace Contexts
{
    public class SignalContext : MVCSContext
    {
        public SignalContext() : base() { }
        public SignalContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
        }

        public override IContext Start()
        {
            base.Start();
            var startSignal = injectionBinder.GetInstance<StartSignal>();
            startSignal.Dispatch();
            return this;
        }
    }

    public class MainContext : SignalContext
    {
        public MainContext() : base() { }
        public MainContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            injectionBinder.Bind<IDataLoader>().To<AsyncsResourcesDataLoader>().CrossContext();
            injectionBinder.Bind<AttachRoomEdgesSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ScenesService>().ToSingleton().CrossContext();
            injectionBinder.Bind<DataService>().ToSingleton().CrossContext();
            injectionBinder.Bind<SpawnService>().ToSingleton().CrossContext();
            injectionBinder.Bind<NewSpawnRootSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<StartPlayerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadingSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<SpawnPlayerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ChangeLevelSignal>().ToSingleton().CrossContext();

            commandBinder.Bind<StartSignal>()
                .To<LoadDataCommand>()
                .To<AddCamerasSceneCommand>()
                .To<AddMenuSceneCommand>()
                .InSequence()
                .Once();

            commandBinder.Bind<ChangeLevelSignal>()
                .To<CheckChangeLevelInfoCommand>()
                .To<AddLoadingSceneCommand>()
                .To<RemoveCallerSceneCommand>()
                .To<AddTargetSceneCommand>()
                .InSequence();
        }
    }
}