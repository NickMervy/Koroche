using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MenuTools
    {
        [MenuItem("Tools/Clear PlayerPrefs")]
        private static void ClearPlayerPrefsAll()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("All PlayerPrefs keys cleared");
        }

        [MenuItem("Tools/Delete Saves")]
        private static void DeleteSaves()
        {
            var constants = new Constants();

            File.Delete(constants.SavesPath);
            Debug.Log("All saves deleted");
        }
    }
}