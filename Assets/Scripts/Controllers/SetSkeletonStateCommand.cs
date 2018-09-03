using Models;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class SetSkeletonStateCommand : Command
    {
        [Inject] public StatesService StatesService { get; set; }
        [Inject] public SkeletonView SkeletonView { get; set; }

        public override void Execute()
        {
            var id = SkeletonView.Id;
            var state = StatesService.GetState(id);

            SkeletonView.SetState(state);
        }
    }
}