using strange.extensions.command.impl;
using Services;

namespace Controllers
{
    public class SetNotAssignedStatesListCommand : Command
    {
        [Inject] public StatesService StatesService { get; set; }

        public override void Execute()
        {
            var states = StatesService.CurrentGameState.CharacterStates;
            foreach (var s in states)
            {
                StatesService.NotAssignedStates.Add(s);
            }
        }
    }
}