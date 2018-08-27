using System.Collections;
using Models;
using strange.extensions.command.impl;
using UniRx;
using UnityEngine;

namespace Controllers
{
    public class WaitForActivesCommand : Command
    {
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }
        [Inject] public int ProcessesCounter { get; set; }

        public override void Execute()
        {
            Retain();
            Observable.FromMicroCoroutine(_ => WaitCoroutine()).Subscribe();
        }

        private IEnumerator WaitCoroutine()
        {
            while (ProcessesCounter != 0)
            {
                yield return null;
            }

            OnComplete();
        }

        private void OnComplete()
        {
            Debug.Log("WaitForActivesCommand Released");
            Release();
        }
    }
}