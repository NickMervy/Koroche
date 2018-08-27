using System.Collections;
using strange.extensions.command.impl;
using UniRx;
using UnityEditor;
using ILogger = Services.ILogger;

namespace Controllers
{
    public class AppExitCommand : Command
    {
        [Inject] public ILogger Logger { get; set; }

        public override void Execute()
        {
            Logger.Log("ClosingApp");
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE_WIN
            Application.Quit();
#endif
        }
    }
}