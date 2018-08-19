using Models;
using strange.extensions.command.impl;
using Services;
using UniRx;
using UnityEngine;

namespace Controllers
{
    public class AsyncLoadDataCommand : Command
    {
        [Inject] public DataService DataService { get; set; }
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }

        public override void Execute()
        {
            ChangeLevelData.ParallelProcesses++;
            DataService.LoadPrefabs(OnComplete);
        }

        private void OnComplete()
        {
            Debug.Log("LoadDataCommand released");
            ChangeLevelData.ParallelProcesses--;
        }
    }
}