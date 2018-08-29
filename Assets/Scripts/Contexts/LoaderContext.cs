using Controllers;
using Models;
using Services;
using Signals;
using UnityEngine;
using View;
using ILogger = Services.ILogger;

namespace Contexts
{
    public class LoaderContext : SignalContext
    {
        public LoaderContext() : base() { }
        public LoaderContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            #region InjectionBinder
            injectionBinder.Bind<GuidService>().ToSingleton().CrossContext();
            injectionBinder.Bind<ILogger>().To<UnityLogger>().ToSingleton().CrossContext();
            injectionBinder.Bind<ILoader>().To<AsyncsResourcesLoader>().ToName<DataService>().CrossContext();
            injectionBinder.Bind<ISurrogatePacket>().To<UnitySurrogatePacket>().ToName<BinaryFormatterFileLoader>().CrossContext();
            injectionBinder.Bind<ISurrogatePacket>().To<UnitySurrogatePacket>().ToName<BinaryFormatterFileSaver>().CrossContext();
            injectionBinder.Bind<ILoader>().To<BinaryFormatterFileLoader>().ToName<FileStatesService>().CrossContext();
            injectionBinder.Bind<ISaver>().To<BinaryFormatterFileSaver>().ToName<FileStatesService>().CrossContext();
            injectionBinder.Bind<IStatesService>().To<FileStatesService>().ToSingleton().CrossContext();
            injectionBinder.Bind<GameStartData>().ToSingleton().CrossContext();
            injectionBinder.Bind<ScenesService>().ToSingleton().CrossContext();
            injectionBinder.Bind<DataService>().ToSingleton().CrossContext();
            injectionBinder.Bind<RandomService>().ToSingleton().CrossContext();
            injectionBinder.Bind<StartPlayerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<NewGameSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ContinueGameSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ShowLoadingScreenSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<HideLoadingScreenSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<Constants>().ToSingleton().CrossContext();
            #endregion

            #region CommandBinder
            commandBinder.Bind<StartSignal>()
                .To<LoadSavesCommand>()
                .To<LoadDataCommand>()
                .To<AddCamerasSceneCommand>()
                .InSequence()
                .Once();

            commandBinder.Bind<NewGameSignal>()
                .To<CheckChangeLevelInfoCommand>()
                .To<ShowLoadingScreenCommand>()
                .To<RemoveCallerSceneCommand>()
                .To<NewGameStateCommand>()
                .To<AddTargetSceneCommand>()
                .To<WaitForAnyInputCommand>()
                .To<HideLoadingScreenCommand>()
                .To<SetStartGameStateCommand>()
                .InSequence();

            commandBinder.Bind<ContinueGameSignal>()
                .To<ShowLoadingScreenCommand>()
                .To<RemoveCallerSceneCommand>()
                .To<LoadGameCommand>()
                .To<AddTargetSceneCommand>()
                .To<WaitForAnyInputCommand>()
                .To<HideLoadingScreenCommand>()
                .To<SetStartGameStateCommand>()
                .InSequence();
            #endregion

            #region MediationBinder
            mediationBinder.Bind<LoadingView>().To<LoadingMediator>();
            #endregion
        }
    }
}