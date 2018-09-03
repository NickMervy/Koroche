using System.Linq;
using strange.extensions.command.impl;
using Services;
using View;

namespace Controllers
{
    public class SetLazyPrefabsCommand : Command
    {
        [Inject] public LazySpawnerView LazySpawnerView { get; set; }
        [Inject] public StatesService StateService { get; set; }
        [Inject] public DataService DataService { get; set; }

        public override void Execute()
        {
            var states = StateService.CurrentGameState.CharacterStates;
            var models = DataService.Characters;

            foreach (var s in states)
            {
                var model = models.First(m => m.Id == s.ModelId);
                LazySpawnerView.Prefabs.Add(model.Prefab);
            }
        }
    }
}