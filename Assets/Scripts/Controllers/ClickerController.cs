using Managers;
using UnityEngine;

namespace Controllers
{
    public class ClickerController : MonoBehaviour
    {
        [SerializeField] private float _clickTime;
        [SerializeField] private int _clickDamage;

        private float _currentClickTimer;
        

        private void Start()
        {
            GameManager.Instance.UpdateController.OnFrameUpdated += HandleFrameUpdated;
        }

        private void HandleFrameUpdated(float deltaTime)
        {
            _currentClickTimer += deltaTime;

            if (_currentClickTimer >= _clickTime)
            {
                GameManager.Instance.Shards += _clickDamage;
                GameManager.Instance.ScreenDurability -= _clickDamage;

                _currentClickTimer = 0f;
            }
        }
    }
}