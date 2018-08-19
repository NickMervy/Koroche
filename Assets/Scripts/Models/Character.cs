﻿using System;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class Character
    {
        public string Name;
        public int Health;
        public int Damage;
        public int MoveSpeed;
        public string Id;
        public GameObject Prefab;
    }
}