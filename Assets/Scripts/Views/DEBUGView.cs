using TMPro;
using UnityEngine;

namespace Views
{
    public class DEBUGView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _clickCounter;
        [SerializeField] private TextMeshProUGUI _oneSecondCounter;

        private int _clickCount;
        private int _oneSecondCount;

        public void UpdateClickCounter()
        {
            _clickCount++;
            _clickCounter.text = _clickCount.ToString();
        }

        public void UpdateOneSecondTimer()
        {
            _oneSecondCount++;
            _oneSecondCounter.text = _oneSecondCount.ToString();
        }
    }
}