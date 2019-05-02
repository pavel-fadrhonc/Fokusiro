using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameStats
    {
        #region Singleton
        
        private static GameStats _instance;

        public static GameStats instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameStats();

                return _instance;
            }
        }

        private GameStats()
        {
        }
        
        #endregion

        public event Action GameStatsChangedEvent;

        private float _focus;
        public float Focus
        {
            get => _focus; 
            set
            {
                _focus = Mathf.Clamp(value, 0, MaxFocus);
                GameStatsChangedEvent?.Invoke();
            }
        }
        
        private float _time;
        public float Time
        {
            get => _time;
            set
            {
                _time = Mathf.Clamp(value, 0, MaxTime); 
                GameStatsChangedEvent?.Invoke();
            }
        }
        
        private float _maxFocus;
        public float MaxFocus
        {
            get => _maxFocus;
            set
            {
                _maxFocus = value;
                GameStatsChangedEvent?.Invoke();
            }
        }

        private float _maxTime;
        public float MaxTime
        {
            get => _maxTime;
            set
            {
                _maxTime = value;
                GameStatsChangedEvent?.Invoke();                
            }
        }

        private float _elapsedTimeInDay;

        public float ElapsedTimeInDay
        {
            get => _elapsedTimeInDay;
            set
            {
                _elapsedTimeInDay = value;
                GameStatsChangedEvent?.Invoke();
            }
        }

        private int _day;

        public int Day
        {
            get => _day;
            set
            {
                _day = value;
                GameStatsChangedEvent?.Invoke();
            }
        }
    }
}