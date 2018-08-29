using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Services
{
    public class ResourcesLoader : ILoader
    {
        [Inject] public ILogger Logger { get; set; }

        public void Load<T>(string path, Action<T> callback)
        {
            try
            {
                var asset = Resources.Load(path);
                if (asset == null)
                    throw new FileNotFoundException();

                callback((T) Convert.ChangeType(asset, typeof(T)));
            }

            catch (InvalidCastException e)
            {
                Logger.LogError(e.Message);
                throw;
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find asset by path: {0}/{1}",
                    Application.dataPath, path));
                Logger.LogError(e.Message);
                throw;
            }
        }
    }
}