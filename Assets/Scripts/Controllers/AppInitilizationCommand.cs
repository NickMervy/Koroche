using strange.extensions.command.impl;
using strange.extensions.context.impl;
using Services;
using Signals;

namespace Controllers
{
    public class AppInitilizationCommand : Command
    {
        public override void Execute()
        {
            injectionBinder.Bind<IDataLoader>().To<AsyncsResourcesDataLoader>().CrossContext();
            injectionBinder.Bind<AttachRoomEdgesSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ScenesService>().ToSingleton().CrossContext();
            injectionBinder.Bind<DataService>().ToSingleton().CrossContext();
            injectionBinder.Bind<SpawnService>().ToSingleton().CrossContext();
            injectionBinder.Bind<NewSpawnRootSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ChangeLevelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<StartPlayerSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadingSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<SpawnPlayerSignal>().ToSingleton().CrossContext();
        }
    }
}