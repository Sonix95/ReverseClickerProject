using System.Collections;
using System.Collections.Generic;
using Configs;
using Enums;
using Models;
using UnityEngine;
using Upgrades;
using Views;

namespace Controllers
{
    public class UpgradeSelectorController : MonoBehaviour
    {
        [SerializeField] private UpgradeSelectorView _upgradeSelectorView;

        private UpgradesConfig _upgradesConfig;

        private List<UpgradeModel> _upgrades;
        private List<UpgradeModel> _selectedUpgrades;

        private IUpgradeFacade _upgradeFacade;

        private void Awake()
        {
            _upgradesConfig = Resources.Load<UpgradesConfig>("Configs/UpgradesConfig");

            _upgradeFacade = new UpgradeFacade();

            _upgrades = new List<UpgradeModel>();
            _selectedUpgrades = new List<UpgradeModel>();

            _upgradeSelectorView.OnUpgradeSelected += HandleOnUpgradeSelected;
        }

        private void OnEnable()
        {
            StartCoroutine(ShowUpgrades());
        }

        private void ResetUpgrades()
        {
            _selectedUpgrades.Clear();

            _upgrades.Clear();
            _upgrades.AddRange(_upgradesConfig.Upgrades);
        }

        private void UpdateUpgrades()
        {
            for (int i = 0; i < 2; i++)
            {
                var randomIndex = Random.Range(0, _upgrades.Count);
                _selectedUpgrades.Add(_upgrades[randomIndex]);
                _upgrades.RemoveAt(randomIndex);
            }
        }

        private IEnumerator ShowUpgrades()
        {
            ResetUpgrades();
            UpdateUpgrades();
            yield return new WaitForSeconds(1f);
            _upgradeSelectorView.Enable(_selectedUpgrades);
        }

        private void HandleOnUpgradeSelected(UpgradeTypes upgrade)
        {
            _upgradeFacade.Upgrade(upgrade);

            _upgradeSelectorView.Disable();

            StartCoroutine(ShowUpgrades());
        }
    }
}