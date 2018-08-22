using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "PrefabsContainer", menuName = "Containers/Prefabs Container")]
    public class PrefabsContainer : ScriptableObject
    {
        [SerializeField] private List<CharacterModel> _characters;

        public List<CharacterModel> Characters { get {return _characters; } }
    }
}