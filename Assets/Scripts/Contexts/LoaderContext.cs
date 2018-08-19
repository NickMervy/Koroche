using Controllers;
using Services;
using Signals;
using UnityEngine;
using View;

namespace Contexts
{
    public class LoaderContext : SignalContext
    {
        public LoaderContext() : base() { }
        public LoaderContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            #region InjectionBinder
            injectionBinder.Bind<IDataLoader>().To<AsyncsResourcesDataLoader>().ToName<DataService>().CrossContext();
            injectionBinder.Bind<IDataLoader>().To<JsonPlayerPrefsDataLoader>().ToName<StateService>().CrossContext();
            injectionBinder.Bind<IDataSaver>().To<JsonPlayerPrefsDataSaver>().ToName<StateService>().CrossContext();
            injectionBinder.Bind<AttachRoomEdgesSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ScenesService>().ToSingleton().CrossContext();
            injectionBinder.Bind<StateService>().ToSingleton().CrossContext();
            injectionBinder.Bind<SpawnService>().ToSingleton().CrossContext();
            injectionBinder.Bind<DataService>().ToSingleton().CrossContext();
            injectionBinder.Bind<NewSpawnRootSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<StartPlayerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<SpawnPlayerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<NewGameSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<AsyncNewGameSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ContinueGameSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowLoadingScreenSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<HideLoadingScreenSignal>().ToSingleton().CrossContext();
            #endregion

            #region CommandBinder
            commandBinder.Bind<StartSignal>()
                .To<AddCamerasSceneCommand>()
                .To<AddMenuSceneCommand>()
                .InSequence()
                .Once();

            commandBinder.Bind<AsyncNewGameSignal>()
                .To<CheckChangeLevelInfoCommand>()
                .To<ShowLoadingScreenCommand>()
                .To<AsyncRemoveCallerSceneCommand>()
                .To<AsyncLoadDataCommand>()
                .To<NewGameStateCommand>()
                .To<AsyncAddTargetSceneCommand>()
                .To<WaitForActivesCommand>()
                .To<WaitForAnyInputCommand>()
                .To<HideLoadingScreenCommand>()
                .InSequence();

            commandBinder.Bind<NewGameSignal>()
                .To<CheckChangeLevelInfoCommand>()
                .To<ShowLoadingScreenCommand>()
                .To<RemoveCallerSceneCommand>()
                .To<LoadDataCommand>()
                .To<NewGameStateCommand>()
                .To<AddTargetSceneCommand>()
                .To<WaitForAnyInputCommand>()
                .To<HideLoadingScreenCommand>()
                .InSequence();

            commandBinder.Bind<ContinueGameSignal>()
                .To<ShowLoadingScreenCommand>()
                .To<RemoveCallerSceneCommand>()
                .To<LoadGameStateCommand>()
                .To<LoadDataCommand>()
                .To<AsyncAddTargetSceneCommand>()
                .To<WaitForAnyInputCommand>()
                .To<HideLoadingScreenCommand>()
                .InSequence();
            #endregion

            #region MediationBinder
            mediationBinder.Bind<LoadingView>().To<LoadingViewMediator>();
            #endregion
        }
    }
}