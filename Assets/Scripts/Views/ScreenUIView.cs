using System;
using System.Collections.Generic;
using System.Linq;
using Componets;
using Enums;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

namespace Views
{
    public class ScreenUIView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentTimeLabel = default;
        [SerializeField] private TextMeshProUGUI _timerLabel = default;
        [SerializeField] private Slider _screenDurabilitySlideBar = default;
        [SerializeField] private TextMeshProUGUI _screenDurabilityLabel = default;
        [SerializeField] private TextMeshProUGUI _shardsLabel = default;
        [SerializeField] private CanvasGroup _canvasGroup = default;

        [SerializeField] private RectTransform _upgradesPanelRoot = default;
        [SerializeField] private UpgradeButtonComponent _upgradeButtonPrefab = default;

        private Dictionary<UpgradeTypes, UpgradeButtonComponent> _upgrades = default;
        
        private float _timerValue;

        private void Start()
        {
            _upgrades = new Dictionary<UpgradeTypes, UpgradeButtonComponent>();

            _currentTimeLabel.text = DateTime.Now.ToShortTimeString();
            _timerLabel.text = GetTimerString(0);

            _screenDurabilitySlideBar.minValue = 0;
            _screenDurabilitySlideBar.maxValue = GameManager.Instance.ScreenDurability;
            _screenDurabilitySlideBar.value = GameManager.Instance.ScreenDurability;
            _screenDurabilityLabel.text = GameManager.Instance.ScreenDurability.ToString();

            _shardsLabel.text = GameManager.Instance.Shards.ToString();

            GameManager.Instance.UpdateController.OnOneSecondPassed += HandleOneSecondPassed;
            GameManager.Instance.UpdateController.OnTicked += HandleTicked;
            GameManager.Instance.OnScreenDurabilityUpdated += HandleScreenDurabilityUpdated;
            GameManager.Instance.OnShardsCountUpdated += HandleShardsCountUpdated;
            GameManager.Instance.OnStart += HandleStart;
            GameManager.Instance.UpgradeSelectorController.UpgradeUpdated += HandleUpdateUpgrated;
        }

        private void HandleUpdateUpgrated(IUpgrade upgrade)
        {
            if (_upgrades.Keys.Contains(upgrade.UpgradeType))
            {
                _upgrades[upgrade.UpgradeType].UpdateLevelIcon(upgrade.Rank.ToString());
            }
            else
            {
                var upgradeButton = Instantiate(_upgradeButtonPrefab, _upgradesPanelRoot);
                upgradeButton.Init(upgrade);
                _upgrades.Add(upgrade.UpgradeType, upgradeButton);
            }
        }

        private void HandleStart()
        {
            _canvasGroup.alpha = 1.0f;
        }

        private void HandleShardsCountUpdated()
        {
            _shardsLabel.text = GameManager.Instance.Shards.ToString();
        }

        private void HandleScreenDurabilityUpdated()
        {
            _screenDurabilitySlideBar.value = GameManager.Instance.ScreenDurability;
            _screenDurabilityLabel.text = GameManager.Instance.ScreenDurability.ToString();
        }

        private void HandleTicked()
        {
            _currentTimeLabel.text = DateTime.Now.ToShortTimeString();
        }
        private void HandleOneSecondPassed()
        {
            _timerValue++;
            _timerLabel.text = GetTimerString(_timerValue);
        }

        private string GetTimerString(float time)
        {
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            return $"{minutes:00}:{seconds:00}";
        }
    }
}
