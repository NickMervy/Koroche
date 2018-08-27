using strange.extensions.command.impl;
using Services;
using UnityEngine;
using ILogger = Services.ILogger;

namespace Controllers
{
    public class AddMenuSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public Constants Constants { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public override void Execute()
        {
            var sceneName = Constants.MenuScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Logger.LogWarning(string.Format(
                    @"""{0}"" scene is already loaded", sceneName));
                return;
            }

            Retain();
            var operation = ScenesService.LoadAsync(sceneName);
            operation.OnComplete(Callback);
        }

        public void Callback()
        {
            Logger.Log("AddMenuSceneCommand Released");
            Release();
        }
    }
}