using Configs.Upgrades;
using Enums;
using Managers;
using Models;
using UnityEngine;

namespace Upgrades
{
    public class PowerDrainUpgrade : IUpgrade
    {
        public Sprite Image { get; private set; }
        public string Name { get; }
        public string Description { get; private set; }
        public UpgradeTypes UpgradeType { get; }

        public int Rank => _rank;
        public bool IsMax => _rank > _config.Rankers.Count - 1;

        private PowerDrainUpgradeConfig _config;
        private int _rank;
        private string _description;

        public PowerDrainUpgrade(UpgradeModel model)
        {
            _config = Resources.Load<PowerDrainUpgradeConfig>("Configs/Upgrades/PowerDrainUpgradeConfig");
            _rank = 0;
            _description = model.Description;

            Image = _config.Rankers[_rank].Image;
            Name = model.Name;
            Description = string.Format(_description, _config.Rankers[_rank].DecreaseClickPowerInPercents, _config.Rankers[_rank].Duration);
            UpgradeType = model.UpgradeType;
        }
        
        public void UpdateRank()
        {
            _rank++;

            if (!IsMax)
            {
                Description = string.Format(_description, _config.Rankers[_rank].DecreaseClickPowerInPercents, _config.Rankers[_rank].Duration);
                Image = _config.Rankers[_rank].Image;
            }
        }

        public void Use()
        {
            GameManager.Instance.ClickerController.SetTempDamage(_config.Rankers[_rank].DecreaseClickPowerInPercents, _config.Rankers[_rank].Duration);
        }

        public float GetTimer()
        {
            return _config.Rankers[_rank].Duration;
        }
    }
}
