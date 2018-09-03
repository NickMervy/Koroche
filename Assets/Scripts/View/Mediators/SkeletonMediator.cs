using Models;
using Signals;
using UnityEngine;

namespace View
{
    class SkeletonMediator : TargetMediator<SkeletonView>
    {
        [Inject] public AttackSignal AttackSignal { get; set; }
        [Inject] public StartSkeletonSignal StartSkeletonSignal { get; set; }
        [Inject] public CharacterHealthUpdateSignal CharacterUpdateStateSignal { get; set; }
        [Inject] public CharacterDeathSignal CharacterDeathSignal { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            View.SkeletonStart += HandleSkeletonStart;
            CharacterUpdateStateSignal.AddListener(HandleCharacterUpdateStateSignal);
            CharacterDeathSignal.AddListener(HandleCharacterDeathSignal);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            View.SkeletonStart -= HandleSkeletonStart;
            CharacterUpdateStateSignal.RemoveListener(HandleCharacterUpdateStateSignal);
            CharacterDeathSignal.RemoveListener(HandleCharacterDeathSignal);
        }

        protected void HandleSkeletonStart()
        {
            StartSkeletonSignal.Dispatch(View);
        }

        private void HandleCharacterUpdateStateSignal(int key, ICharacterState state)
        {
            if (key != View.Id)
                return;

            Debug.Log(state.Health);
        }

        private void HandleCharacterDeathSignal(int key)
        {
            if (key != View.Id)
                return;

            Destroy(View.gameObject);
        }
    }
}