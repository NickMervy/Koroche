using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class CharacterState
    {
        public int Health;
        public int Damage;
        public float MoveSpeed;
        public Vector3 Position;
    }
}