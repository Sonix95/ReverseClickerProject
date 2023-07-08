using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Configs.Upgrades
{
    [CreateAssetMenu(fileName = "PowerDrainUpgradeConfig", menuName = "Configs/Upgrades/Create PowerDrainUpgradeConfig")]
    public class PowerDrainUpgradeConfig : ScriptableObject
    {
        public List<PowerDrainUpgradeModel> Rankers;
    }
}