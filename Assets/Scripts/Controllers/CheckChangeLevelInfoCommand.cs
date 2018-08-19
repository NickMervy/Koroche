using System;
using Models;
using strange.extensions.command.impl;
using UnityEngine;

namespace Controllers
{
    public class CheckChangeLevelInfoCommand : Command
    {
        [Inject] public ChangeLevelData ChangeLevelData { get; set; }

        public override void Execute()
        {
            try
            {
                if (string.IsNullOrEmpty(ChangeLevelData.CallerScene))
                    throw new ArgumentException("", "callerScene");
                if (string.IsNullOrEmpty(ChangeLevelData.TargetScene))
                    throw new ArgumentException("", "targetScene");
            }

            catch (ArgumentException e)
            {
                var param = e.ParamName;
                e = new ArgumentNullException(
                    string.Format("Couldn't change level: invalid value in {0}", param));
                Debug.LogErrorFormat(e.Message);
                Fail();
                throw;
            }
        }
    }
}