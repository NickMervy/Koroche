using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class GameState
    {
        public readonly List<ICharacterState> CharacterStates = new List<ICharacterState>();
    }
}