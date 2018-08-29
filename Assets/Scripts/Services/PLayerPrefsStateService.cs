using System;
using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Services
{
    public class PLayerPrefsStatesService : IStatesService
    {
        [Inject(typeof(PLayerPrefsStatesService))] public ISaver Saver { get; set; }
        [Inject(typeof(PLayerPrefsStatesService))] public ILoader Loader { get; set; }
        [Inject] public Constants Constants { get; set; }
        [Inject] public ILogger Logger { get; set; }

        private UserState _userState = new UserState();

        public UserState UserState
        {
            get { return _userState; }
        }

        public GameState CurrentGameState { get; set; }

        public ICharacterState PlayerState { get; set; }

        public bool HasSaves
        {
            get { return PlayerPrefs.HasKey(Constants.SavesKey); }
        }

        public void Load()
        {
            Loader.Load<UserState>(Constants.SavesKey, gs =>
            {
                _userState = gs;
            });
        }

        public void Load(Action callback)
        {
            Loader.Load<UserState>(Constants.SavesKey, gs =>
            {
                _userState = gs;
                callback();
            });
        }

        public void Save()
        {
            Saver.Save(_userState, Constants.SavesKey);
            Logger.Log("GameState saved");
        }
    }
}