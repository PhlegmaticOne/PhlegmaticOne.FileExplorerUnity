﻿using PhlegmaticOne.FileExplorer.Configuration;
using UnityEngine;
using UnityEngine.UI;

namespace PhlegmaticOne.FileExplorer.ExploreSample
{
    public class ExploreFilesBehaviour : MonoBehaviour
    {
        [SerializeField] private Button _exploreButton;
        [SerializeField] private ExplorerConfigScriptable _configScriptable;

        private IExplorer _explorer;
        
        private void Awake()
        {
            Application.targetFrameRate = 60; 
            _exploreButton.onClick.AddListener(OpenExplorer);

            _explorer = new Explorer(_configScriptable);
        }

        private async void OpenExplorer()
        {
            var showResult = await _explorer.Open();
            Debug.Log($"Explorer is showed: {showResult.IsShowed}");
        }
    }
}