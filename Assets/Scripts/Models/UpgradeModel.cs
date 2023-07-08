using System;
using Enums;
using UnityEngine;

namespace Models
{
    [Serializable]
    public class UpgradeModel
    {
        public string Name;
        public UpgradeTypes UpgradeType;
        public Sprite Image;
        public string Description;
    }
}
