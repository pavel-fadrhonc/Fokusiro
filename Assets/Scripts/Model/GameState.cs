using System;

namespace DefaultNamespace
{
    public enum eGameState
    {
        Running,
        Ended
    }
    
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

        public Action<eGameState> GameStateChanged;
        
        private eGameState _state;

        public eGameState State
        {
            get => _state;
            set
            {
                if (value != _state)
                {
                    _state = value;
                    GameStateChanged?.Invoke(_state);
                }
            }
        }

        public void Init()
        {
            State = eGameState.Running;
            GameEvents.instance.TimesUp += () => State = eGameState.Ended;
            GameEvents.instance.TimeEatenByDistractions += () => State = eGameState.Ended;
        }
    }
}