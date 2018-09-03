using System;
using UnityEngine;

namespace Models
{
    public interface ICharacterState
    {
        int Health { get; set; }
        int Damage { get; set; }
        int MoveSpeed { get; set; }
        Vector3 Position { get; set; }
        string ModelId { get; set; }
    }

    [Serializable]
    public class PlayerState : ICharacterState
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int MoveSpeed { get; set; }
        public Vector3 Position { get; set; }
        public string ModelId { get; set; }
    }

    [Serializable]
    public class SkeletonState : ICharacterState
    {
        public int Health { get; set; }
        public int Damage { get; set; }
        public int MoveSpeed { get; set; }
        public Vector3 Position { get; set; }
        public string ModelId { get; set; }
    }
}