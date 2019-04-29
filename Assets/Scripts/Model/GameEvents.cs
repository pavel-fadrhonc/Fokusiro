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

        public event Action TimesUp;

        public event Action TimeEatenByDistractions;
        
        public void Init()
        {
            GameStats.instance.GameStatsChangedEvent += OnGameStatsChangedHandler;
        }

        private void OnGameStatsChangedHandler()
        {
            if (GameStats.instance.Focus >= GameStats.instance.MaxFocus)
                FlowReached?.Invoke();
            else if (GameStats.instance.Focus <= 0)
                FocusDepleted?.Invoke();
            else if (GameStats.instance.Time <= (GameStats.instance.MaxTime * Locator.Instance.ProjectConstants.FailState) &&
                     GameState.instance.State == eGameState.Running)
                TimeEatenByDistractions?.Invoke();
        }

        public void BroadCastTimesUpEvent()
        {
            if (GameState.instance.State != eGameState.Running)
                return;
            
            TimesUp?.Invoke();   
        }
    }
}