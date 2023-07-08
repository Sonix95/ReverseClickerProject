using System;
using UnityEngine;

namespace Controllers
{
    public class AppUpdateController : MonoBehaviour
    {
        public event Action OnTicked;
        public event Action<float> OnFrameUpdated;
        public event Action OnOneSecondPassed;

        private float _oneSecondTimer = 0.0f;
        private bool _isFreezeTime = false;

        private void LateUpdate()
        {
            OnTicked?.Invoke();
        }

        private void Update()
        {
            if (!_isFreezeTime)
            {
                FrameUpdated(Time.deltaTime);

                _oneSecondTimer += Time.deltaTime;
                if (_oneSecondTimer >= 1.0f)
                {
                    OneSecondPassed();
                    _oneSecondTimer = 0f;
                }
            }
        }

        private void FrameUpdated(float deltaTime)
        {
            OnFrameUpdated?.Invoke(deltaTime);
        }

        private void OneSecondPassed()
        {
            OnOneSecondPassed?.Invoke();
        }

        public void UnFreezeTime()
        {
            _isFreezeTime = false;
        }

        public void FreezeTime()
        {
            _isFreezeTime = true;
        }
    }
}
