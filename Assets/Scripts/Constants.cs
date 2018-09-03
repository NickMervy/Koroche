using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public sealed class Constants
{
    public readonly string LoaderScene = "Loader";
    public readonly string MenuScene = "Menu";
    public readonly string DesertUona = "DesertUona";
    public readonly string UIScene = "UI";
    public readonly string CamerasScene = "Cameras";

    public readonly string PrefabsContainerPath = "PrefabsContainer";
    public readonly string SavesKey = "GameStates";
    public readonly string SavesPath = Application.persistentDataPath + "/Saves.che";
}