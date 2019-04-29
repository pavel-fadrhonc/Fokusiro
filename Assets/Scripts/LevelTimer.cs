using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelTimer : MonoBehaviour
    {
        public TextMeshProUGUI dayTimeText;

        private float _elapsedTime;

        private readonly float _9amseconds = 9 * 60 * 60;
        private readonly float _5pmseconds = 17 * 60 * 60;
        private StringBuilder _stringBuilder = new StringBuilder();

        private void Awake()
        {
            GameEvents.instance.TimeEatenByDistractions += () => enabled = false;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            var daySeconds = (_elapsedTime * 8 * 60f * 60f) / Locator.Instance.ProjectConstants.DayDuration;
            var totalSecond = _9amseconds + daySeconds;
            if ((totalSecond) > _5pmseconds)
            {
                dayTimeText.text = "17:00";
                GameEvents.instance.BroadCastTimesUpEvent();
                enabled = false;
                return;                
            }            
            
            var hours = Mathf.Floor(totalSecond / (60f * 60f));
            var minutes = Mathf.Floor(totalSecond / (60f)) - (hours * 60);
            _stringBuilder.Clear();
            if (hours < 10 )
                _stringBuilder.Append('0');
            
            _stringBuilder.Append(hours.ToString());
            _stringBuilder.Append(':');
            
            if (minutes < 10)
                _stringBuilder.Append('0');
            
            _stringBuilder.Append(minutes.ToString());

            dayTimeText.text = _stringBuilder.ToString();
        }
    }
}