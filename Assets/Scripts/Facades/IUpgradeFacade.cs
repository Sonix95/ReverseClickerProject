using Enums;
using Models;

namespace Upgrades
{
    public interface IUpgradeFacade
    {
        void Upgrade(UpgradeTypes upgradeType);
        IUpgrade GetUpgrade(UpgradeTypes upgrade);
    }
}