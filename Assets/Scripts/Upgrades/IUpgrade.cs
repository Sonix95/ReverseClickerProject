using System;
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
        void Use();
        float GetTimer();

        //string Name { get; }
        //void UpdateRank();
        //void Activate();
        //void Stop();
        //void ChargeBoost(bool forceFullCharge = false);
        //void UpdateBoostAfterCharge();
    }
}
