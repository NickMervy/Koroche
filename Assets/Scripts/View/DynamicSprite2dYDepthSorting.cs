using UniRx;
using UnityEngine;

namespace View
{
    public class DynamicSprite2dYDepthSorting : MonoBehaviour
    {
        [SerializeField] private int _scaler = 100;
        private SpriteRenderer _spriteRenderer;
        private Transform _transform;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            Observable.EveryLateUpdate().Subscribe(_ =>
            {
                var feetTransform = _transform.TransformPoint(_spriteRenderer.sprite.bounds.min);
                _spriteRenderer.sortingOrder = -(int) (feetTransform.y*_scaler);
            }).AddTo(this);
        }
    }
}