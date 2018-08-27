using strange.extensions.command.impl;
using Services;
using ILogger = Services.ILogger;

namespace Controllers
{
    public class AddDesertUonaSceneCommand : Command
    {
        [Inject] public ScenesService ScenesService { get; set; }
        [Inject] public Constants Constants { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public override void Execute()
        {
            var sceneName = Constants.DesertUona;
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
            Logger.Log("AddGameSceneCommand released");
            Release();
        }
    }
}