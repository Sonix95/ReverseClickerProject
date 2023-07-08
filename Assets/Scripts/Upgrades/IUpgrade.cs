using Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Upgrades
{
    public interface IUpgrade
    {
        Sprite Image { get; }
        string Name { get; }
        string Description { get; }
        UpgradeTypes UpgradeType { get; }


        int Rank { get; }
        bool IsMax { get; }

        void UpdateRank();

        //string Name { get; }
        //void UpdateRank();
        //void Activate();
        //void Use();
        //void Stop();
        //void ChargeBoost(bool forceFullCharge = false);
        //void UpdateBoostAfterCharge();
    }
}
