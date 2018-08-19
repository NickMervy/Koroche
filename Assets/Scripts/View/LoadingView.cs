using strange.extensions.mediation.impl;
using UnityEngine;

namespace View
{
    public class LoadingView : EventView
    {
        [SerializeField] private GameObject _loadingScreen;

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }
    }
}