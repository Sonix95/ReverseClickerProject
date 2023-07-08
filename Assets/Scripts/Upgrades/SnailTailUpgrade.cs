using Configs.Upgrades;
using UnityEngine;

namespace Upgrades
{
    public class SnailTailUpgrade : IUpgrade
    {
        private int _rank;

        public int Rank { get; }
        public bool IsMax => _rank >= _config.Rankers.Count;

        private SnailTailUpgradeConfig _config;

        public SnailTailUpgrade()
        {
            _config = Resources.Load<SnailTailUpgradeConfig>("Configs/Upgrades/SnailTailUpgradeConfig");
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
