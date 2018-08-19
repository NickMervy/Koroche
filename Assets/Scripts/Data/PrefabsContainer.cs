using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "Containers/Prefabs Container")]
    public class PrefabsContainer : ScriptableObject
    {
        [SerializeField] private List<Character> _characters;

        public List<Character> Characters { get {return _characters; } }
    }
}