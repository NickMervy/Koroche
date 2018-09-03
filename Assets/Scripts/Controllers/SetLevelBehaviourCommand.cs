using Contexts;
using Models;
using strange.extensions.command.impl;

namespace Controllers
{
    public class SetLevelBehaviourCommand : Command
    {
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }

        public override void Execute()
        {
            LevelContext.LevelBehaviour = ChangeLevelData.LevelBehaviour;
        }
    }
}