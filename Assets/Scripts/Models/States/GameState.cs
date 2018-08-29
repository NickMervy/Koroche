using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class GameState
    {
        public string Name;
        public Dictionary<string, ICharacterState> CharacterStates = new Dictionary<string, ICharacterState>();
    }
}