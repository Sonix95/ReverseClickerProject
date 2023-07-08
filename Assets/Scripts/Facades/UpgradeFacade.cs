using System.Collections.Generic;
using System.Linq;
using Configs;
using Enums;
using Models;

namespace Upgrades
{
    public class UpgradeFacade : IUpgradeFacade
    {
        private Dictionary<UpgradeTypes, IUpgrade> _upgradeObjects;

        private UpgradesConfig _upgradesConfig;

        public UpgradeFacade(UpgradesConfig upgradesConfig)
        {
            _upgradeObjects = new Dictionary<UpgradeTypes, IUpgrade>();
            _upgradesConfig = upgradesConfig;
        }

        public void Upgrade(UpgradeTypes upgradeType)
        {
            if (_upgradeObjects.ContainsKey(upgradeType))
            {
                _upgradeObjects[upgradeType].UpdateRank();
                return;
            }

            var model = _upgradesConfig.Upgrades.FirstOrDefault(x => x.UpgradeType == upgradeType);

            if (model != null)
            {
                switch (upgradeType)
                {
                    case UpgradeTypes.SnailTail:
                        _upgradeObjects.Add(UpgradeTypes.SnailTail, new SnailTailUpgrade(model));
                        break;
                    case UpgradeTypes.PowerDrain:
                        _upgradeObjects.Add(UpgradeTypes.PowerDrain, new PowerDrainUpgrade(model));
                        break;
                }
                _upgradeObjects[upgradeType].UpdateRank();
            }
        }

        public IUpgrade GetUpgrade(UpgradeTypes upgrade)
        {
            if (_upgradeObjects.ContainsKey(upgrade))
            {
                return _upgradeObjects[upgrade];
            }

            var model = _upgradesConfig.Upgrades.FirstOrDefault(x => x.UpgradeType == upgrade);

            if (model != null)
            {
                switch (upgrade)
                {
                    case UpgradeTypes.SnailTail:
                        return new SnailTailUpgrade(model);
                        
                    case UpgradeTypes.PowerDrain:
                        return new PowerDrainUpgrade(model);
                }
            }

            return null;
        }

        public void Clear()
        {
            _upgradeObjects.Clear();
        }
    }
}
