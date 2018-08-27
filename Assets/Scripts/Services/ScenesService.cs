using System;
using System.Collections;
using Models;
using Signals;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    public class ScenesService
    {
        [Inject] public ILogger Logger { get; set; }

        public AsyncOperation LoadAsync(string name, LoadSceneMode loadMode = LoadSceneMode.Additive)
        {
            Logger.Log(string.Format(
                @"Loading started: ""{0}"" ", name));

            var operation = SceneManager.LoadSceneAsync(name, loadMode);
            operation.OnComplete(() =>
            {
                Logger.Log(string.Format(
                    @"Loading finished: ""{0}"" ", name));
            });

            return operation;
        }

        public AsyncOperation LoadAsync(string name, Action callback, LoadSceneMode loadMode = LoadSceneMode.Additive)
        {
            Logger.Log(string.Format(
                @"Loading started: ""{0}"" ", name));

            var operation = SceneManager.LoadSceneAsync(name, loadMode);
            operation.OnComplete(() =>
            {
                Logger.Log(string.Format(
                    @"Loading finished: ""{0}"" ", name));
                callback();
            });

            return operation;
        }

        public AsyncOperation UnloadAsync(string name)
        {
            Logger.Log(string.Format(
                @"Unloading started: ""{0}"" ", name));

            var operation = SceneManager.UnloadSceneAsync(name);
            operation.OnComplete(() =>
            {
                Logger.Log(string.Format(
                    @"Unloading finished: ""{0}"" ", name));
            });

            return operation;
        }

        public AsyncOperation UnloadAsync(string name, Action callback)
        {
            Logger.Log(string.Format(
                @"Unloading started: ""{0}"" ", name));

            var operation = SceneManager.UnloadSceneAsync(name);
            operation.OnComplete(() =>
            {
                Logger.Log(string.Format(
                    @"Unloading finished: ""{0}"" ", name));
                callback();
            });

            return operation;
        }

        public bool IsAdded(string name)
        {
            return SceneManager.GetSceneByName(name).name == name;
        }
    }
}