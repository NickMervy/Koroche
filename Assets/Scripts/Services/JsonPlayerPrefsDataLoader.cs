using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public class JsonPlayerPrefsDataLoader : IDataLoader
    {
        [Inject] public ILogger Logger { get; set; }

        public void Load<T>(string key, Action<T> callback)
        {
            try
            {
                if (!PlayerPrefs.HasKey(key))
                    throw new FileNotFoundException();

                var json = PlayerPrefs.GetString(key);
                Debug.Log("Loaded: " + typeof(T));
                callback(JsonUtility.FromJson<T>(json));
            }

            catch (FileNotFoundException e)
            {
                e = new FileNotFoundException(
                    string.Format("Couldn't find JsonFile marked by key: '{0}'", key));
                Logger.LogError(e.Message);
                callback(default(T));
            }
        }
    }
}