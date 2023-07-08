using Configs.Upgrades;
using Enums;
using Managers;
using Models;
using UnityEngine;

namespace Upgrades
{
    public class SnailTailUpgrade : IUpgrade
    {
        public Sprite Image { get; }
        public string Name { get; }
        public string Description { get; private set; }
        public UpgradeTypes UpgradeType { get; }

        public int Rank => _rank;
        public bool IsMax => _rank > _config.Rankers.Count - 1;

        private SnailTailUpgradeConfig _config;
        private int _rank;
        private string _description;

        public SnailTailUpgrade(UpgradeModel model)
        {
            _config = Resources.Load<SnailTailUpgradeConfig>("Configs/Upgrades/SnailTailUpgradeConfig");
            _rank = 0;
            _description = model.Description;

            Image = model.Image;
            Name = model.Name;
            Description = string.Format(_description, _config.Rankers[_rank].SlowClicksInPercents, _config.Rankers[_rank].Duration);
            UpgradeType = model.UpgradeType;
        }

        public void UpdateRank()
        {
            _rank++;

            if (!IsMax)
            {
                Description = string.Format(_description, _config.Rankers[_rank].SlowClicksInPercents, _config.Rankers[_rank].Duration);
            }
        }

        public void Use()
        {
            GameManager.Instance.ClickerController.SetTempSpeed(_config.Rankers[_rank].SlowClicksInPercents, _config.Rankers[_rank].Duration);
        }
        public float GetTimer()
        {
            return _config.Rankers[_rank].Duration;
        }
    }
}
