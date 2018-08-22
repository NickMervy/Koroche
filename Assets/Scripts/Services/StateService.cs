using System;
using Models;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Services
{
    public class StateService
    {
        [Inject(typeof(StateService))] public IDataSaver Saver { get; set; }
        [Inject(typeof(StateService))] public IDataLoader Loader { get; set; }

        public GameState GameState { get; private set; }

        public void LoadGameState()
        {
            Loader.Load<GameState>(Constants.GameStateKey, gs =>
            {
                GameState = gs;
            });
        }

        public void LoadGameState(Action callback)
        {
            Loader.Load<GameState>(Constants.GameStateKey, gs =>
            {
                GameState = gs;
                callback();
            });
        }

        public void SaveGameState()
        {
            Saver.Save(GameState, Constants.GameStateKey);
            Debug.Log("GameState saved");
        }

        public void NewGameState()
        {
            GameState = new GameState();
            Debug.Log("New GameState created");
        }

        public bool HasSaves(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
    }
}