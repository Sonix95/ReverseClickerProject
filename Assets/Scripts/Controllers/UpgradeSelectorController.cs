using System;
using System.Collections;
using System.Collections.Generic;
using Configs;
using Enums;
using Managers;
using Models;
using UnityEngine;
using Upgrades;
using Views;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class UpgradeSelectorController : MonoBehaviour
    {
        public event Action<IUpgrade> UpgradeUpdated;

        [SerializeField] private UpgradeSelectorView _upgradeSelectorView;

        private UpgradesConfig _upgradesConfig;
        private WavesConfig _waveConfig;

        private List<UpgradeModel> _upgrades;
        private List<IUpgrade> _selectedUpgrades;

        private IUpgradeFacade _upgradeFacade;

        private int _currentWave;
        private int _currentWaveEndTime;
        private int _currentTime;

        private void Awake()
        {
            _upgradesConfig = Resources.Load<UpgradesConfig>("Configs/UpgradesConfig");
            _waveConfig = Resources.Load<WavesConfig>("Configs/WavesConfig");

            _upgradeFacade = new UpgradeFacade(_upgradesConfig);

            _upgrades = new List<UpgradeModel>();
            _selectedUpgrades = new List<IUpgrade>();
            _upgradeSelectorView.OnUpgradeSelected += HandleOnUpgradeSelected;
            GameManager.Instance.UpdateController.OnOneSecondPassed += HandleOneSecondPassed;

            _currentWave = 0;
            _currentWaveEndTime = _waveConfig.Waves[_currentWave].Duration;
            _currentTime = 0;
        }

        private void HandleOneSecondPassed()
        {
            _currentTime++;
            if (_currentTime >= _currentWaveEndTime)
            {
                GameManager.Instance.UpdateController.FreezeTime();
                StartCoroutine(ShowUpgrades());
            }
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
                var upgradeType = _upgrades[randomIndex].UpgradeType;
                var upgrade = _upgradeFacade.GetUpgrade(upgradeType);
                if (!upgrade.IsMax)
                {
                    _selectedUpgrades.Add(upgrade);
                }
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

            UpgradeUpdated?.Invoke(_upgradeFacade.GetUpgrade(upgrade));

            _upgradeSelectorView.Disable();

            _currentWave++;
            if (_currentWave >= _waveConfig.Waves.Count)
            {
                _currentWave = _waveConfig.Waves.Count - 1;
            }
            _currentWaveEndTime += _waveConfig.Waves[_currentWave].Duration;
            
            GameManager.Instance.UpdateController.UnFreezeTime();
            GameManager.Instance.ClickerController.EnterNewWave();
        }
    }
}