using Models;
using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;
using ILogger = Services.ILogger;

namespace Controllers
{
    public class AsyncLoadDataCommand : Command
    {
        [Inject] public DataService DataService { get; set; }
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }
        [Inject] public int ProcessesCounter { get; set; }
        [Inject] public ILogger Logger { get; set; }

        public override void Execute()
        {
            ProcessesCounter++;
            DataService.LoadPrefabs(OnComplete);
        }

        private void OnComplete()
        {
            Logger.Log("LoadDataCommand released");
            ProcessesCounter--;
        }
    }
}