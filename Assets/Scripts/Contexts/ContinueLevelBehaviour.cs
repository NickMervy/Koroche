using Controllers;
using Signals;

namespace Contexts
{
    public class ContinueLevelBehaviour : ILevelBehaviour
    {
        public void MapBindings(LevelContext levelContext)
        {
            var commandBinder = levelContext.commandBinder;

            commandBinder.Bind<DefaultSpawnerSignal>();
            commandBinder.Bind<LazySpawnerSignal>()
                .To<SetLazyPrefabsCommand>()
                .To<LazySpawnCommand>()
                .InSequence();
            commandBinder.Bind<StartPlayerSignal>()
                .To<AssignPlayerStateCommand>()
                .To<SetPlayerStateCommand>();
            commandBinder.Bind<StartSkeletonSignal>()
                .To<AssignSkeletonStateCommand>()
                .To<SetSkeletonStateCommand>();
        }
    }
}