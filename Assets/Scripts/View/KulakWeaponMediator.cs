using Models;
using Signals;
using UnityEngine;

namespace View
{
    public class KulakWeaponMediator : TargetMediator<KulakWeaponView>
    {
        [Inject] public AttackSignal AttackSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.Hit += HandleHit;
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.Hit -= HandleHit;
        }

        private void HandleHit(Collider2D col)
        {
            Debug.Log("Hit");
            var defenderId = col.GetComponent<UniqueId>().Id;

            AttackSignal.Dispatch(new AttackInfo
            {
                AttackerId = View.ParentId,
                DefenderId = defenderId
            });
        }
    }
}