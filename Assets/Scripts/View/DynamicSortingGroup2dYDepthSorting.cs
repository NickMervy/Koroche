using UniRx;
using UnityEngine;
using UnityEngine.Rendering;

namespace View
{
    public class DynamicSortingGroup2dYDepthSorting : MonoBehaviour
    {
        [SerializeField] private int _scaler = 100;
        private SortingGroup _sortingGroup;
        private Transform _transform;

        private void Awake()
        {
            _sortingGroup = GetComponent<SortingGroup>();
            _transform = GetComponent<Transform>();
        }

        private void Start()
        {
            Observable.EveryLateUpdate().Subscribe(_ =>
            {
                var feetTransform = _transform.position;
                _sortingGroup.sortingOrder = -(int)(feetTransform.y * _scaler);
            }).AddTo(this);
        }
    }
}