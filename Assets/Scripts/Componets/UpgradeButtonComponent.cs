using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Upgrades;

namespace Componets
{
    public class UpgradeButtonComponent : MonoBehaviour
    {
        [SerializeField] private Image _spriteBack;
        [SerializeField] private Image _spriteFront;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Button _button;

        private IUpgrade _upgrade;
        private float _cooldown;
        private float _cooldownTimer;

        private void OnUpgradeClick()
        {
            _upgrade.Use();
            _button.interactable = false;
            _spriteFront.fillAmount = 1.0f;
            _cooldownTimer = 0;
            _cooldown = _upgrade.GetTimer();
        }

        public void UpdateLevelIcon(int rank)
        {
            _level.text = _upgrade.Rank.ToString();
        }

        public void Init(IUpgrade upgrade)
        {
            _button.onClick.AddListener(OnUpgradeClick);
            GameManager.Instance.UpdateController.OnFrameUpdated += HandleOnFrameUpdated;
            _upgrade = upgrade;

            _spriteBack.sprite = _upgrade.Image;
            _spriteFront.fillAmount = 0.0f;
            _name.text = _upgrade.Name;
            _level.text = _upgrade.Rank.ToString();
        }

        private void HandleOnFrameUpdated(float delta)
        {
            if (_button.interactable)
            {
                return;
            }

            UpdateCooldown(delta);
        }

        private void UpdateCooldown(float delta)
        {
            _cooldownTimer += delta;
            float percentageComplete = _cooldownTimer / _cooldown;

            _spriteFront.fillAmount = Mathf.Lerp(1, 0, percentageComplete);

            if (_cooldownTimer >= _cooldown)
            {
                _button.interactable = true;
            }
        }
    }
}
