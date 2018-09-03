using System.Linq;
using Models;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class NewSkeletonStateCommand : Command
    {
        [Inject] public DataService DataService { get; set; }
        [Inject] public StatesService StatesService { get; set; }
        [Inject] public SkeletonView SkeletonView { get; set; }

        public override void Execute()
        {
            var model = DataService.Characters.First(p => p.Id == "Skeleton");
            var guid = SkeletonView.Id;

            var state = new SkeletonState()
            {
                Health = model.Health,
                Damage = model.Damage,
                ModelId = model.Id,
                MoveSpeed = model.MoveSpeed,
                Position = SkeletonView.transform.position
            };

            StatesService.AddState(guid, state);
        }
    }
}