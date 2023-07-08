using Enums;

namespace Upgrades
{
    public interface IUpgradeFacade
    {
        void Upgrade(UpgradeTypes upgrade);
    }
}