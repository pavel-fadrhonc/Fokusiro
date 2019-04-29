using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.UI
{
    public class ExposeGameEvents : MonoBehaviour
    {
        public float delay;
        public UnityEvent OnLevelFailed;

        private void OnEnable()
        {
            GameEvents.instance.TimeEatenByDistractions += OnLevelFailedHandler;
        }

        private void OnDisable()
        {
            GameEvents.instance.TimeEatenByDistractions -= OnLevelFailedHandler;
        }

        private void OnLevelFailedHandler()
        {
            StartCoroutine(InvokeLevelFailedDelayed(delay));
        }

        private IEnumerator InvokeLevelFailedDelayed(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            OnLevelFailed.Invoke();
        }
    }
}