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

        public event Action GameStateChangedEvent;

        private float _focus;
        public float Focus
        {
            get => _focus; 
            set
            {
                _focus = Mathf.Clamp(value, 0, MaxFocus);
                GameStateChangedEvent?.Invoke();
            }
        }
        
        private float _time;
        public float Time
        {
            get => _time;
            set
            {
                _time = Mathf.Clamp(value, 0, MaxTime); 
                GameStateChangedEvent?.Invoke();
            }
        }
        
        private float _maxFocus;
        public float MaxFocus
        {
            get => _maxFocus;
            set
            {
                _maxFocus = value;
                GameStateChangedEvent?.Invoke();
            }
        }

        private float _maxTime;
        public float MaxTime
        {
            get => _maxTime;
            set
            {
                _maxTime = value;
                GameStateChangedEvent?.Invoke();                
            }
        }        
    }
}