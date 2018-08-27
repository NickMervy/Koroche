using Cinemachine;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class VirtualCamera2DView : EventView
    {
        [SerializeField] private CinemachineVirtualCamera _virtCamera;

        public void SetFollowTarget(GameObject obj)
        {
            _virtCamera.Follow = obj.transform;
        }
    }
}