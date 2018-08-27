using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CharacterState
    {
        public int Health;
        public Vector3 Position;
        public CharacterModel Model;
    }
}