using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public class JsonFileLoader : ILoader
    {
        [Inject] public ILogger Logger { get; set; }

        public void Load<T>(string path, Action<T> callback)
        {
            try
            {
                if (!File.Exists(path))
                    throw new FileNotFoundException();

                using (var stream = new StreamReader(path))
                {
                    var text = stream.ReadToEnd();
                    callback(JsonUtility.FromJson<T>(text));
                }
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find file by path: {0}", path));
                Logger.LogWarning(e.Message);
            }
        }
    }
}