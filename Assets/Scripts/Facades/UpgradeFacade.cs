using System.Collections.Generic;
using Enums;

namespace Upgrades
{
    public class UpgradeFacade : IUpgradeFacade
    {
        private Dictionary<UpgradeTypes, IUpgrade> _upgradeObjects;

        public UpgradeFacade()
        {
            _upgradeObjects = new Dictionary<UpgradeTypes, IUpgrade>();
        }

        public void Upgrade(UpgradeTypes upgrade)
        {
            if (_upgradeObjects.ContainsKey(upgrade))
            {
                _upgradeObjects[upgrade].UpdateRank();
                return;
            }

            switch (upgrade)
            {
                case UpgradeTypes.SnailTail:
                    _upgradeObjects.Add(UpgradeTypes.SnailTail, new SnailTailUpgrade());
                    break;
                case UpgradeTypes.PowerDrain:
                    _upgradeObjects.Add(UpgradeTypes.PowerDrain, new PowerDrainUpgrade());
                    break;
            }
        }

        public IUpgrade GetUpgrade(UpgradeTypes upgrade)
        {
            if (_upgradeObjects.ContainsKey(upgrade))
            {
                return _upgradeObjects[upgrade];
            }

            return null;
        }

        public void Clear()
        {
            _upgradeObjects.Clear();
        }
    }
}
