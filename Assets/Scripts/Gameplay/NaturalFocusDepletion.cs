using UnityEngine;

namespace DefaultNamespace
{
    public class NaturalFocusDepletion : MonoBehaviour
    {
        [Tooltip("in focus points per second")]
        public float rate;
        public float updateRate;

        private float _nextUpdate;
        private bool _gameEnded = false;

        private void Awake()
        {
            _nextUpdate = Time.time + updateRate;
        }

        private void OnEnable()
        {
            GameEvents.instance.TimesUp += OnTimesUp;
            GameEvents.instance.TimeEatenByDistractions += OnTimeEatenByDistractions;            
        }

        private void OnDisable()
        {
            GameEvents.instance.TimesUp -= OnTimesUp;
            GameEvents.instance.TimeEatenByDistractions -= OnTimeEatenByDistractions;                        
        }

        private void OnTimesUp()
        {
            _gameEnded = true;
        }

        private void OnTimeEatenByDistractions()
        {
            _gameEnded = true;
        }
        
        private void Update()
        {
            if (Time.time < _nextUpdate)
                return;
            
            if (PlayerState.instance.State != ePlayerState.Normal)
                return;            
            
            if (_gameEnded)
                return;

            _nextUpdate += updateRate;
            
            GameStats.instance.Focus -= rate * updateRate;
        }
    }
}