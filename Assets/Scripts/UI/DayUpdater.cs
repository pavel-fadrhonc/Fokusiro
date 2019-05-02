using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class DayUpdater : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<TextMeshProUGUI>().text = GameStats.instance.Day.ToString();
        }
    }
}