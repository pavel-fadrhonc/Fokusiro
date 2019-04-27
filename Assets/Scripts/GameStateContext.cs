using System;

namespace DefaultNamespace
{
    public class GameStateContext 
    {
        #region Singleton
        
        private static GameStateContext _instance;

        public static GameStateContext instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameStateContext();

                return _instance;
            }
        }

        private GameStateContext()
        {
        }
        
        #endregion

        public Action GameStateContextChangedEvent;
        
        private float _maxFocus;
        public float MaxFocus
        {
            get => _maxFocus;
            set
            {
                _maxFocus = value;
                GameStateContextChangedEvent?.Invoke();
            }
        }

        private float _maxTime;
        public float MaxTime
        {
            get => _maxTime;
            set
            {
                _maxTime = value;
                GameStateContextChangedEvent?.Invoke();                
            }
        }
    }
}