﻿using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Networking;

namespace View
{
    public class PlayerAnimationsHandler : MonoBehaviour
    {
        [SerializeField] private PlayerAxisController _playerController;
        [SerializeField] private Animator _anim;

        public void Start()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                var xAxis = _playerController.AxisX;
                var yAxis = _playerController.AxisY;

                if (xAxis == 0 && yAxis == 0)
                {
                    _anim.SetBool("IsMove", false);
                }

                else if (xAxis != 0 || yAxis != 0)
                {
                    _anim.SetBool("IsMove", true);
                }

                _anim.SetFloat("Vx", xAxis);
                _anim.SetFloat("Vy", yAxis);
            }).AddTo(this);
        }
    }
}