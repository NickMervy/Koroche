using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    [RequireComponent(typeof(UniqueId))]
    public class CharacterView : EventView
    {
        private UniqueId _uniqueId;

        protected override void Awake()
        {
            base.Awake();
            _uniqueId = GetComponent<UniqueId>();
        }

        public int Id
        {
            get
            {
                return _uniqueId.Id;
            }
        }
    }
}