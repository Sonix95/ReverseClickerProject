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
        [SerializeField] private ClickerController _clickerController;

        [SerializeField] private Slider _startBar;
        [SerializeField] private CanvasGroup _startCanvas;

        private static GameManager _instance;
        public static GameManager Instance => _instance;

        public AppUpdateController UpdateController => _updateController;
        public UpgradeSelectorController UpgradeSelectorController => _upgradeSelectorController;
        public ClickerController ClickerController => _clickerController;

        private float _shards = 0;
        private float _screenDurability = 1000;
        private bool _isStarted = false;

        public float Shards
        {
            get => _shards;
            set
            {
                _shards = value;
                OnShardsCountUpdated?.Invoke();
            }
        }

        public float ScreenDurability
        {
            get => _screenDurability;
            set
            {
                _screenDurability = value;
                if (_screenDurability <= 0)
                {
                    GameOver();
                }
                else
                {
                    OnScreenDurabilityUpdated?.Invoke();
                }
            }
        }

        private void GameOver()
        {
            _updateController.FreezeTime();
            _startBar.value = 0;
            _startCanvas.alpha = 1.0f;
            _isStarted = false;

            _shards = 0;
            _screenDurability = 1000;
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
