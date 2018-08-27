using UnityEngine;

namespace View
{
    class SkeletonMediator : TargetMediator<SkeletonView>
    {
        public override void OnRegister()
        {
            base.OnRegister();
            View.TriggerEnter2D += HandleTriggerEnter2D;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.TriggerEnter2D -= HandleTriggerEnter2D;
        }

        protected void HandleTriggerEnter2D(Collider2D col2D)
        {
            
        }
    }
}