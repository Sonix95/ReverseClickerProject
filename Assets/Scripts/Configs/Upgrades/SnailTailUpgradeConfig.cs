using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Configs.Upgrades
{
    [CreateAssetMenu(fileName = "SnailTailUpgradeConfig", menuName = "Configs/Upgrades/Create SnailTailUpgradeConfig")]
    public class SnailTailUpgradeConfig : ScriptableObject
    {
        public List<SnailTailUpgradeModel> Rankers;
    }
}