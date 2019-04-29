using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelLoader : MonoBehaviour
    {
        public string levelToLoad;

        private void Awake()
        {
            GameEvents.instance.TimesUp += OnTimesUp;
        }

        private void OnTimesUp()
        {
            StartCoroutine(LoadNextLevelWithDelay(3.5f));
        }

        private IEnumerator LoadNextLevelWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            SceneManager.LoadScene(levelToLoad);
        }
    }
}