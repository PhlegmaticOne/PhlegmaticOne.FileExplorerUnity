using System;
using UnityEngine;

namespace PhlegmaticOne.FileExplorer.Features.Navigation.Listeners
{
    [Serializable]
    internal sealed class LoadingTextConfig
    {
        [SerializeField] private string _loadingTextValue = "Loading";
        [SerializeField] private int _pointsCount = 3;
        [SerializeField] private float _changePointDuration = 0.3f;

        public string LoadingTextValue => _loadingTextValue;
        public int PointsCount => _pointsCount;
        public float ChangePointDuration => _changePointDuration;
    }
}