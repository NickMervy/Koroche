using Models;
using strange.extensions.command.impl;
using Services;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class AttackCommand : Command
    {
        [Inject] public AttackInfo AttackInfo { get; set; }
        [Inject] public StatesService StatesService { get; set; }
        [Inject] public CharacterHealthUpdateSignal CharacterUpdateStateSignal { get; set; }
        [Inject] public CharacterDeathSignal CharacterDeathSignal { get; set; }

        private ICharacterState _attackerState;
        private ICharacterState _defenderState;

        public override void Execute()
        {
            _attackerState = StatesService.GetState(AttackInfo.AttackerId);
            _defenderState = StatesService.GetState(AttackInfo.DefenderId);

            _defenderState.Health = Mathf.Max(0, _defenderState.Health - _attackerState.Damage);
            if (_defenderState.Health == 0)
            {
                CharacterDeathSignal.Dispatch(AttackInfo.DefenderId);
            }

            CharacterUpdateStateSignal.Dispatch(AttackInfo.DefenderId, _defenderState);
        }
    }
}