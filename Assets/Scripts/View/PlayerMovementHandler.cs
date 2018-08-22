using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Services;
using UniRx;
using UniRx.Triggers;

namespace View
{
    public class PlayerMovementHandler : MonoBehaviour
    {
        public float Speed;
        [SerializeField] private PlayerAxisController _playerController;
        [SerializeField] private Rigidbody2D _rigidBody2d;

        public void Start()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                var xAxis = _playerController.AxisX;
                var yAxis = _playerController.AxisY;

                var vector = new Vector2(xAxis, yAxis);
                _rigidBody2d.velocity = Speed * vector.normalized;
            }).AddTo(this);
        }
    }
}
