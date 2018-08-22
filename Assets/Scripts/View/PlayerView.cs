using System;
using Models;
using strange.extensions.mediation.impl;

namespace View
{
    public class PlayerView : EventView
    {
        public event Action PlayerSpawn;
        private PlayerMovementHandler _playerMovement;

        protected override void Awake()
        {
            base.Awake();
            _playerMovement = GetComponent<PlayerMovementHandler>();
        }

        protected override void Start()
        {
            base.Start();
            OnPlayerSpawn();
        }

        protected virtual void OnPlayerSpawn()
        {
            var handler = PlayerSpawn;
            if (handler != null) handler();
        }

        public void Init(CharacterModel model)
        {
            _playerMovement.Speed = model.MoveSpeed;
        }
    }
}