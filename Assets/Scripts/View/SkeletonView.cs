using System;
using Models;

namespace View
{
    public class SkeletonView : CharacterView
    {
        public event Action SkeletonStart;

        protected override void Start()
        {
            base.Start();
            OnSkeletonStart();
        }

        protected virtual void OnSkeletonStart()
        {
            var handler = SkeletonStart;
            if (handler != null) handler();
        }

        public void SetState(ICharacterState state)
        {
            gameObject.transform.position = state.Position;
        }
    }
}