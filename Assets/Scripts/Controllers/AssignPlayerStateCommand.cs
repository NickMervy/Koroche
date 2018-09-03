using System.Linq;
using Models;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class AssignPlayerStateCommand : Command
    {
        [Inject] public StatesService StatesService { get; set; }
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            var states = StatesService.NotAssignedStates;
            var state = states.First(cs => cs is PlayerState);
            var id = PlayerView.Id;

            StatesService.AddState(id, state);
            states.Remove(state);
        }
    }
}