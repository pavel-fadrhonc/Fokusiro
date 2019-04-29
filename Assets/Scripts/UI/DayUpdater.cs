using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class DayUpdater : MonoBehaviour
    {
        private void Awake()
        {
            var sceneName = SceneManager.GetActiveScene().name;
            var dayStr = sceneName.Substring(sceneName.LastIndexOf('_') + 1);
            int day;
            if (!Int32.TryParse(dayStr, out day))
                return;

            GetComponent<TextMeshProUGUI>().text = dayStr;
        }
    }
}