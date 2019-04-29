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
            
            GameEvents.instance.TimesUp += () => _gameEnded = true;
            GameEvents.instance.TimeEatenByDistractions += () => _gameEnded = true;
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