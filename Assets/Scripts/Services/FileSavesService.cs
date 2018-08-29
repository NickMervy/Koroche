using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;

namespace Services
{
    public class FileStatesService : IStatesService
    {
        [Inject(typeof(FileStatesService))] public ISaver Saver { get; set; }
        [Inject(typeof(FileStatesService))] public ILoader Loader { get; set; }
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
            get
            {
                return _userState.Saves.Any();
            }
        }

        public void Load()
        {
            Loader.Load<UserState>(Constants.SavesPath, gs =>
            {
                _userState = gs;
                Logger.Log("GameState loaded");
            });
        }

        public void Load(Action callback)
        {
            Loader.Load<UserState>(Constants.SavesPath, gs =>
            {
                _userState = gs;
                Logger.Log("GameState loaded");
                callback();
            });
        }

        public void Save()
        {
            Saver.Save(_userState, Constants.SavesPath);
            Logger.Log(string.Format(
                @"Saved by path: ""{0}""", Constants.SavesPath));
        }
    }
}