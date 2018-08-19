using System.Collections;
using Models;
using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;

namespace Controllers
{
    public class AddTargetSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }

        public override void Execute()
        {
            Retain();
            var sceneName = ChangeLevelData.TargetScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already loaded", sceneName);
                return;
            }

            var operation = ScenesService.LoadAsync(sceneName);
            ChangeLevelData.Operation = operation;
            Observable.FromMicroCoroutine(_ => LoadingCoroutine(operation)).Subscribe();
        }

        private IEnumerator LoadingCoroutine(AsyncOperation operation)
        {
            operation.allowSceneActivation = false;

            while (!Mathf.Approximately(operation.progress, 0.9f))
                yield return null;

            OnComplete();
        }

        private void OnComplete()
        {
            Debug.Log("LoadDataCommand released");
            Release();
        }
    }
}