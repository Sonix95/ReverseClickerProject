using System;
using UnityEngine;
using UnityEngine.UI;

namespace Componets
{
    public class UpgradeButtonComponent : MonoBehaviour
    {
        public event Action OnUpgradeClicked;

        [SerializeField] private Image _spriteBack;
        [SerializeField] private Image _spriteFront;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(OnUpgradeClick);
        }

        private void OnUpgradeClick()
        {
            OnUpgradeClicked?.Invoke();
        }
    }
}