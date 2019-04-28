using UnityEngine;

namespace DefaultNamespace
{
    public class NaturalFocusDepletion : MonoBehaviour
    {
        [Tooltip("in focus points per second")]
        public float rate;
        public float updateRate;

        private float _nextUpdate;

        private void Awake()
        {
            _nextUpdate = Time.time + updateRate;
        }

        private void Update()
        {
            if (Time.time < _nextUpdate)
                return;

            _nextUpdate += updateRate;
            
            GameStats.instance.Focus -= rate * updateRate;
        }
    }
}