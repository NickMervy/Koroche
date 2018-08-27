using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class UserState
    {
        public List<GameState> Saves = new List<GameState>();
    }
}