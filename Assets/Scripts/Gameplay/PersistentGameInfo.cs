using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class PersistentGameInfo : GameSingleton<PersistentGameInfo>
    {
        [Tooltip("if you've completed that level, when you fail in one of next you start on that one.")]
        public List<int> savePointDays;

        private int _furthestCompletedDay;
        public int FurthestCompletedDay => _furthestCompletedDay;

        protected override void Awake()
        {
            base.Awake();

            if (PlayerPrefs.HasKey("LCD"))
            {
                _furthestCompletedDay = PlayerPrefs.GetInt("LCD");
            }
            
            GameEvents.instance.TimesUp += OnLevelSuccess;
        }

        private void OnLevelSuccess()
        {
            if (GameStats.instance.Day > _furthestCompletedDay)
            {
                _furthestCompletedDay = GameStats.instance.Day;
                PlayerPrefs.SetInt("LCD", _furthestCompletedDay);
                PlayerPrefs.Save();                
            }
        }

        public int GetCatchupDay()
        {
            if (_furthestCompletedDay < savePointDays[0])
                return 1;

            return savePointDays.Last(spd => _furthestCompletedDay >= spd);
        }
    }
}