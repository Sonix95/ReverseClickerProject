using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

namespace Componets
{
    public class UpgradeButtonComponent : MonoBehaviour
    {
        public event Action OnUpgradeClicked;

        [SerializeField] private Image _spriteBack;
        [SerializeField] private Image _spriteFront;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Button _button;
        

        private void OnUpgradeClick()
        {
            OnUpgradeClicked?.Invoke();
        }

        public void UpdateLevelIcon(string rank)
        {
            _level.text = rank;
        }

        public void Init(IUpgrade upgrade)
        {
            _button.onClick.AddListener(OnUpgradeClick);
            _spriteBack.sprite = upgrade.Image;
            _spriteFront.sprite = upgrade.Image;
            _name.text = upgrade.Name;
            _level.text = upgrade.Rank.ToString();
        }
    }
}