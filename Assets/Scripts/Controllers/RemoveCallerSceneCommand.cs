using Models;
using strange.extensions.command.impl;
using Services;
using UnityEngine;

namespace Controllers
{
    public class RemoveCallerSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }

        public override void Execute()
        {
            Retain();
            var sceneName = ChangeLevelData.CallerScene;
            if (!ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already unloaded", sceneName);
                return;
            }

            ScenesService.UnloadAsync(sceneName, OnComplete);
        }

        private void OnComplete()
        {
            Debug.Log("LoadDataCommand released");
            Release();
        }
    }
}