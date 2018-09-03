using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Models;

namespace Services
{
    public class StatesService
    {
        [Inject(typeof(StatesService))] public ISaver Saver { get; set; }
        [Inject(typeof(StatesService))] public ILoader Loader { get; set; }
        [Inject] public Constants Constants { get; set; }
        [Inject] public ILogger Logger { get; set; }

        private UserState _userState = new UserState();
        private readonly List<ICharacterState> _notAssignedStates = new List<ICharacterState>(); 
        private readonly Dictionary<int, ICharacterState> _statesDictionary = new Dictionary<int, ICharacterState>();

        public UserState UserState
        {
            get { return _userState; }
        }

        public List<ICharacterState> NotAssignedStates
        {
            get { return _notAssignedStates; }
        }

        public GameState CurrentGameState
        {
            get;
            set;
        }

        public bool HasSaves
        {
            get
            {
                return _userState.Saves.Any();
            }
        }

        public void AddState(int id, ICharacterState state)
        {
            try
            {
                if (_statesDictionary.ContainsKey(id))
                    throw new ArgumentException();

                CurrentGameState.CharacterStates.Add(state);
                _statesDictionary.Add(id, state);
                Logger.Log(string.Format(
                    @"State added. Key: ""{0}"";  State: ""{1}""", id, state));
            }

            catch (ArgumentException e)
            {
                e = new ArgumentException(string.Format(
                    @"States dictionary already contains key: ""{0}""", id)); 
                Logger.LogError(e.Message);
                throw;
            }
        }

        public void RemoveState(int id)
        {
            try
            {
                if (_statesDictionary.ContainsKey(id))
                    throw new ArgumentException();

                var state = _statesDictionary[id];
                CurrentGameState.CharacterStates.Remove(state);
                _statesDictionary.Remove(id);
                Logger.Log(string.Format(
                    @"State removed. Key: ""{0}""; State: ""{1}""", id, state));
            }

            catch (ArgumentException e)
            {
                e = new ArgumentException(string.Format(
                    @"States dictionary already contains key: \n ""{0}""", id));
                Logger.LogError(e.Message);
                throw;
            }
        }

        public ICharacterState GetState(int id)
        {
            try
            {
                if (!_statesDictionary.ContainsKey(id))
                    throw new KeyNotFoundException();

                return _statesDictionary[id];
            }

            catch (KeyNotFoundException e)
            {
                e = new KeyNotFoundException(string.Format(
                    @"StatesDictionary doesn't contain key: ""{0}""", id));
                Logger.LogError(e.Message);
                throw;
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