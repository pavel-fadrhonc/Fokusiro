using System;
using System.Collections;
using System.Collections.Generic;
using OakFramework2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    [Flags]
    public enum eDisabledInputType
    {
        Top = 1,
        Left = 2,
        Right = 4
    }
    
    public class LevelSettings : MonoBehaviour
    {
        public string nextLevelToLoad;

        private void OnEnable()
        {
            GameEvents.instance.TimesUp += OnTimesUp;
        }

        private void OnDisable()
        {
            GameEvents.instance.TimesUp -= OnTimesUp;
        }

        private void OnTimesUp()
        {
            StartCoroutine(LoadNextLevelWithDelay(5f));
        }

        private IEnumerator LoadNextLevelWithDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            
            SceneManager.LoadScene(nextLevelToLoad);
        }
    }
}