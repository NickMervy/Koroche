using System;
using System.Collections.Generic;
using Models;

namespace Services
{
    public interface IStatesService
    {
        ISaver Saver { get; set; }
        ILoader Loader { get; set; }

        UserState UserState { get; }
        GameState CurrentGameState { get; set; }
        ICharacterState PlayerState { get; set; }
        bool HasSaves { get; }

        void Load();
        void Load(Action callback);
        void Save();
    }
}