using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "UpgradesConfig", menuName = "Configs/Create UpgradesConfig")]
    public class UpgradesConfig : ScriptableObject
    {
        public List<UpgradeModel> Upgrades;
    }
}