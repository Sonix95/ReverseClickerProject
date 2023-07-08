using Componets;
using Enums;
using Models;
using System;
using System.Collections.Generic;
using UnityEngine;
using Upgrades;

namespace Views
{
    public class UpgradeSelectorView : MonoBehaviour
    {
        public event Action<UpgradeTypes> OnUpgradeSelected;

        [SerializeField] private CanvasGroup _canvasGroup = default;
        [SerializeField] private RectTransform _upgradesRoot = default;
        [SerializeField] private UpgradeElementView _upgradeElementSample = default;
        
        private List<UpgradeElementView> _upgrades;

        private void Start()
        {
            _upgrades = new List<UpgradeElementView>();
        }

        public void Enable(List<IUpgrade> upgrades)
        {
            foreach (var upgrade in upgrades)
            {
                var upgradeElement = Instantiate(_upgradeElementSample, _upgradesRoot);
                upgradeElement.Init(upgrade.Image, upgrade.Name, upgrade.Description, upgrade.UpgradeType);
                upgradeElement.OnUpgradeSelected += HandleUpgradeSelected;
                _upgrades.Add(upgradeElement);
            }

            _canvasGroup.alpha = 1f;
        }

        public void Disable()
        {
            foreach (var upgrade in _upgrades)
            {
                upgrade.OnUpgradeSelected -= HandleUpgradeSelected;
                Destroy(upgrade.gameObject);
            }

            _upgrades.Clear();
            _canvasGroup.alpha = 0f;
        }

        private void HandleUpgradeSelected(UpgradeTypes upgradeType)
        {
            OnUpgradeSelected?.Invoke(upgradeType);
        }
    }
}