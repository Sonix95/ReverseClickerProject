using System;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class ClickerController : MonoBehaviour
    {
        public event Action OnTempDamageEnd;
        public event Action OnTempSpeedEnd;

        [SerializeField] private float _clickTime;
        [SerializeField] private float _clickDamage;
        [SerializeField] private float _newWaveMultiplierDamage;
        [SerializeField] private float _newWaveMultiplierSpeed;

        private float _currentClickTimer;

        private float _currentTempClickTimer;
        private float _currentTempDamageTimer;

        private float _tempClickTimerEnd;
        private float _tempDamageTimerEnd;

        private float _tempClickTime;
        private float _tempDamage;


        private void Start()
        {
            GameManager.Instance.UpdateController.OnFrameUpdated += HandleFrameUpdated;
            _tempClickTime = 0;
            _tempDamage = 0;
        }

        public void EnterNewWave()
        {
            _clickDamage *= _newWaveMultiplierDamage;
            _clickTime /= _newWaveMultiplierSpeed;
        }

        public void SetTempSpeed(int percent, int time)
        {
            _tempClickTime = _clickTime + ((_clickTime / 100) * percent);
            _tempClickTimerEnd = time;
        }

        public void SetTempDamage(int percent, int time)
        {
            _tempDamage = _clickDamage - ((_clickDamage / 100) * percent);
            _tempDamageTimerEnd = time;
        }

        private void HandleFrameUpdated(float deltaTime)
        {
            _currentClickTimer += deltaTime;

            if (_tempClickTimerEnd > 0)
            {
                _currentTempClickTimer += deltaTime;
                if (_currentTempClickTimer >= _tempClickTimerEnd)
                {
                    _tempClickTimerEnd = -1;
                    _currentTempClickTimer = -1;
                    _tempClickTime = -1;
                    OnTempSpeedEnd?.Invoke();
                }
            }

            if (_tempDamageTimerEnd > 0)
            {
                _currentTempDamageTimer += deltaTime;
                if (_currentTempDamageTimer >= _tempDamageTimerEnd)
                {
                    _tempDamageTimerEnd = -1;
                    _currentTempDamageTimer = -1;
                    _tempDamage = -1;
                    OnTempDamageEnd?.Invoke();
                }
            }

            if (_currentClickTimer >= GetClickTime())
            {
                var damage = GetDamage();
                GameManager.Instance.Shards += damage;
                GameManager.Instance.ScreenDurability -= damage;

                _currentClickTimer = 0f;
            }
        }

        private float GetClickTime()
        {
            return _tempClickTime > 0 ? _tempClickTime : _clickTime;
        }

        private float GetDamage()
        {
            return _tempDamage > 0 ? _tempDamage : _clickDamage;
        }
    }
}