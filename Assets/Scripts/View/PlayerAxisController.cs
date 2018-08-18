using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.Networking;

namespace View
{
    public class PlayerAxisController : MonoBehaviour
    {
        public float AxisX { get; private set; }
        public float AxisY { get; private set; }

        public void Start()
        {
            Observable.EveryUpdate().Subscribe(_ =>
            {
                AxisX = Input.GetAxisRaw("Horizontal");
                AxisY = Input.GetAxisRaw("Vertical");
            }).AddTo(this);
        }
    }
}