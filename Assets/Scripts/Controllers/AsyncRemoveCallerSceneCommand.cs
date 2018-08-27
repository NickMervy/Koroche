using Models;
using strange.extensions.command.impl;
using Services;
using UnityEngine;
using ILogger = Services.ILogger;

namespace Controllers
{
    public class AsyncRemoveCallerSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }
        [Inject] public int ProcessesCounter { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public override void Execute()
        {
            var sceneName = ChangeLevelData.CallerScene;
            if (!ScenesService.IsAdded(sceneName))
            {
                Logger.LogWarning(string.Format(
                    @"""{0}"" scene is already unloaded", sceneName));
                return;
            }

            ProcessesCounter++;
            ScenesService.UnloadAsync(sceneName, OnComplete);
        }

        private void OnComplete()
        {
            Logger.Log("LoadDataCommand released");
            ProcessesCounter--;
        }
    }
}