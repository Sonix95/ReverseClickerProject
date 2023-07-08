using System;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public event Action OnStart;
        public event Action OnShardsCountUpdated;
        public event Action OnScreenDurabilityUpdated;

        [SerializeField] private AppUpdateController _updateController;
        [SerializeField] private UpgradeSelectorController _upgradeSelectorController;
        [SerializeField] private Slider _startBar;
        [SerializeField] private CanvasGroup _startCanvas;

        private static GameManager _instance;
        public static GameManager Instance => _instance;

        public AppUpdateController UpdateController => _updateController;
        public UpgradeSelectorController UpgradeSelectorController => _upgradeSelectorController;



        private int _shards = 0;
        private int _screenDurability = 100;
        private bool _isStarted = false;

        public int Shards
        {
            get => _shards;
            set
            {
                _shards = value;
                OnShardsCountUpdated?.Invoke();
            }
        }

        public int ScreenDurability
        {
            get => _screenDurability;
            set
            {
                _screenDurability = value;
                OnScreenDurabilityUpdated?.Invoke();
            }
        }

        private void Awake()
        {
            _updateController.FreezeTime();
            _instance = this;
        }

        private void Update()
        {
            if (!_isStarted)
            {
                if (_startBar.value >= _startBar.maxValue)
                {
                    _isStarted = true;

                    _startCanvas.alpha = 0.0f;

                    OnStart?.Invoke();

                    _updateController.UnFreezeTime();
                }
            }
        }
    }
}