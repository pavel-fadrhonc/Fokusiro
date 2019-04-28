using System;

namespace DefaultNamespace
{
    public class GameEvents
    {
        #region Singleton
        
        private static GameEvents _instance;

        public static GameEvents instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameEvents();

                return _instance;
            }
        }

        private GameEvents()
        {
        }
        
        #endregion

        public event Action FlowReached; 
        public event Action FocusDepleted; 
        
        public void Init()
        {
            GameStats.instance.GameStateChangedEvent += OnGameStateChangedHandler;
        }

        private void OnGameStateChangedHandler()
        {
            if (GameStats.instance.Focus >= GameStats.instance.MaxFocus)
                FlowReached?.Invoke();
            else if (GameStats.instance.Focus <= 0)
                FocusDepleted?.Invoke();
        }
    }
}