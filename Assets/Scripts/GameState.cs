using System;

namespace DefaultNamespace
{
    public class GameState
    {
        #region Singleton
        
        private static GameState _instance;

        public static GameState instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameState();

                return _instance;
            }
        }

        private GameState()
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
                _focus = value;
                GameStateChangedEvent?.Invoke();
            }
        }
        
        private float _time;
        public float Time
        {
            get => _time;
            set
            {
                _time = value; 
                GameStateChangedEvent?.Invoke();
            }
        }
    }
}