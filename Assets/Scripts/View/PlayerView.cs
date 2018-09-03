using System;
using Models;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class PlayerView : CharacterView
    {
        public event Action PlayerStart;

        [SerializeField] private PlayerMovementHandler _playerMovement;

        protected override void Start()
        {
            base.Start();
            OnPlayerStart();
        }

        protected virtual void OnPlayerStart()
        {
            var handler = PlayerStart;
            if (handler != null) handler();
        }

        public void SetState(ICharacterState state)
        {
            _playerMovement.Speed = state.MoveSpeed;
            gameObject.transform.position = state.Position;
        }
    }
}