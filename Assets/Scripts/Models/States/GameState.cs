using System;

namespace Models
{
    [Serializable]
    public class GameState
    {
        public PlayerState PlayerState = new PlayerState();
    }
}