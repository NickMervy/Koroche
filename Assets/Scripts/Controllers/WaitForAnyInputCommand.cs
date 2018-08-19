using System.Collections;
using Models;
using strange.extensions.command.impl;
using UniRx;
using UnityEngine;

namespace Controllers
{
    public class WaitForAnyInputCommand : Command
    {
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }

        public override void Execute()
        {
            Retain();

            var operation = ChangeLevelData.Operation;
            Observable.FromMicroCoroutine(_ => LoadingCoroutine(operation)).Subscribe();
        }

        private IEnumerator LoadingCoroutine(AsyncOperation operation)
        {
            while (!Input.anyKey)
            {
                Debug.Log("Press any key");
                yield return null;
            }

            operation.allowSceneActivation = true;
            OnComplete();
        }

        private void OnComplete()
        {
            Debug.Log("WaitForAnyInputCommand Released");
            Release();
        }
    }
}