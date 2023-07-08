using System;
using Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Componets
{
    public class UpgradeElementView : MonoBehaviour
    {
        public event Action<UpgradeTypes> OnUpgradeSelected;

        [SerializeField] private Image _sprite;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Button _button;

        private UpgradeTypes _upgradeType;

        public void Init(Sprite image, string name, string description, UpgradeTypes upgradeType)
        {
            _sprite.sprite = image;
            _name.text = name;
            _description.text = description;
            _upgradeType = upgradeType;

            _button.onClick.AddListener(OnUpgradeSelect);
        }

        private void OnUpgradeSelect()
        {
            OnUpgradeSelected?.Invoke(_upgradeType);
        }
    }
}
