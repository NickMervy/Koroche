using System.Linq;
using Models;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class AssignSkeletonStateCommand : Command
    {
        [Inject] public StatesService StatesService { get; set; }
        [Inject] public SkeletonView SkeletonView { get; set; }

        public override void Execute()
        {
            var states = StatesService.NotAssignedStates;
            var state = states.First(s => s is SkeletonState);
            var id = SkeletonView.Id;
            
            StatesService.AddState(id, state);
            states.Remove(state);
        }
    }
}