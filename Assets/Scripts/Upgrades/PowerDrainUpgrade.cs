using Configs.Upgrades;
using UnityEngine;

namespace Upgrades
{
    public class PowerDrainUpgrade : IUpgrade
    {
        private int _rank;

        public int Rank { get; }

        public bool IsMax => _rank >= _config.Rankers.Count - 1;

        private PowerDrainUpgradeConfig _config;

        public PowerDrainUpgrade()
        {
            _config = Resources.Load<PowerDrainUpgradeConfig>("Configs/Upgrades/PowerDrainUpgradeConfig");
            Debug.LogError($"Get Upgrade first time");
            _rank = 0;
        }
        
        public void UpdateRank()
        {
            if (!IsMax)
            {
                _rank++;
            }

            Debug.LogError($"UpdateRank {_rank}");
        }
    }
}
