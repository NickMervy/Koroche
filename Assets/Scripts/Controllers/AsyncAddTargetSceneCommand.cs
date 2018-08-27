using System.Collections;
using Models;
using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;
using ILogger = Services.ILogger;

namespace Controllers
{
    public class AsyncAddTargetSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }
        [Inject] public int ProcessesCounter { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public override void Execute()
        {
            var sceneName = ChangeLevelData.TargetScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Logger.LogWarning(string.Format(
                    @"""{0}"" scene is already loaded", sceneName));
                return;
            }

            ProcessesCounter++;
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
            Logger.Log("LoadDataCommand released");
            ProcessesCounter--;
        }
    }
}