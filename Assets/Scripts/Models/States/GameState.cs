using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class GameState
    {
        public string Name;
        public List<CharacterState> CharacterStates = new List<CharacterState>();
    }
}