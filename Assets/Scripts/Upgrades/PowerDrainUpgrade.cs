using Configs.Upgrades;
using Enums;
using Models;
using UnityEngine;

namespace Upgrades
{
    public class PowerDrainUpgrade : IUpgrade
    {
        public Sprite Image { get; }
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

            Image = model.Image;
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
            }
        }
    }
}
