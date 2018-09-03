using Controllers;
using Signals;

namespace Contexts
{
    public class NewLevelBehaviour : ILevelBehaviour
    {
        public void MapBindings(LevelContext levelContext)
        {
            var commandBinder = levelContext.commandBinder;

            commandBinder.Bind<DefaultSpawnerSignal>()
                .To<DefaultSpawnCommand>();
            commandBinder.Bind<LazySpawnerSignal>();
            commandBinder.Bind<StartPlayerSignal>()
                .To<NewPlayerStateCommand>()
                .To<SetPlayerStateCommand>();
            commandBinder.Bind<StartSkeletonSignal>()
                .To<NewSkeletonStateCommand>()
                .To<SetSkeletonStateCommand>();
        }
    }
}