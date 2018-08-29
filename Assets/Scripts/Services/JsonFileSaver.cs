using System.IO;
using UnityEngine;

namespace Services
{
    public class JsonFileSaver : ISaver
    {
        [Inject] public ILogger Logger { get; set; }

        public void Save(object obj, string path)
        {
            if (File.Exists(path))
                Logger.Log(string.Format(
                    @"File overriding by path: ""{0}""", path));
            else if (!File.Exists(path))
                Logger.Log(string.Format(
                    @"New file creating and saving by path: ""{0}""", path));

            using (var stream = File.CreateText(path))
            {
                var json = JsonUtility.ToJson(obj, true);
                stream.Write(json);
            }
        }
    }
}