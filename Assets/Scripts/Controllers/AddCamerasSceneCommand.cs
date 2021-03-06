using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controllers
{
    public class AddCamerasSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }

        public override void Execute()
        {
            var sceneName = Constants.CamerasScene;
            if (ScenesService.IsAdded(sceneName))
            {
                Debug.LogWarningFormat(@"""{0}"" scene is already loaded", sceneName);
                return;
            }

            Retain();
            var operation = ScenesService.LoadAsync(sceneName);
            operation.OnComplete(Callback);
        }

        public void Callback()
        {
            Debug.Log("AddCamerasSceneCommand Released");
            Release();
        }
    }
}