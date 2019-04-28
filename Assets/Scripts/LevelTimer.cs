using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelTimer : MonoBehaviour
    {
        public TextMeshPro dayTimeText;

        private float _elapsedTime;

        private readonly float _9amseconds = 9 * 60 * 60;
        private StringBuilder _stringBuilder = new StringBuilder();

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            var daySeconds = (_elapsedTime * 8 * 60f * 60f) / Locator.Instance.ProjectConstants.DayDuration;
            var totalSecond = _9amseconds + daySeconds;
            var hours = Mathf.Floor(totalSecond / (60f * 60f));
            var minutes = Mathf.Floor(totalSecond / (60f));
            _stringBuilder.Clear();
            _stringBuilder.Append(hours < 10 ? '0' : '');
            _stringBuilder.Append(hours.ToString());
            _stringBuilder.Append(':');
            _stringBuilder.Append(minutes < 10 ? '0' : '');
            _stringBuilder.Append(minutes.ToString());

            dayTimeText.text = _stringBuilder.ToString();


        }
    }
}