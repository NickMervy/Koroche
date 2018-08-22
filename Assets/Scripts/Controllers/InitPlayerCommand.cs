using System.Linq;
using strange.extensions.command.impl;
using Services;
using UnityEngine;
using View;

namespace Controllers
{
    public class InitPlayerCommand : Command
    {
        [Inject] public DataService DataService { get; set; }
        [Inject] public PlayerView PlayerView { get; set; }

        public override void Execute()
        {
            var player = DataService.Characters.First(p => p.Id == "Player");
            PlayerView.Init(player);
        }
    }
}