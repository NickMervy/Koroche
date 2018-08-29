using System;
using Models;
using strange.extensions.mediation.impl;

namespace View
{
    public class PlayerView : EventView
    {
        public event Action PlayerStart;
        public string Guid { get; set; }
        private PlayerMovementHandler _playerMovement;

        protected override void Awake()
        {
            base.Awake();
            _playerMovement = GetComponent<PlayerMovementHandler>();
        }

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