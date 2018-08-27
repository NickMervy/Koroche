using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IStatesService
    {
        IDataSaver Saver { get; set; }
        IDataLoader Loader { get; set; }

        UserState UserState { get; }
        GameState CurrentGameState { get; set; }
        CharacterState PlayerState { get; set; }
        bool HasSaves { get; }

        void Load();
        void Load(Action callback);
        void Save();
    }
}