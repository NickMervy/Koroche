using System;
using System.IO;
using UnityEngine;

namespace Services
{
    public class JsonPlayerPrefsSaver : ISaver
    {
        public void Save(object obj, string key)
        {
            var json = JsonUtility.ToJson(obj, true);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }
    }
}