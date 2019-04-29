using System;

namespace DefaultNamespace
{
    public enum ePlayerState
    {
        Normal,
        Distracted,
        InFlow
    }
    
    public class PlayerState
    {
        #region Singleton
        
        private static PlayerState _instance;

        public static PlayerState instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PlayerState();

                return _instance;
            }
        }

        private PlayerState()
        {
        }
        
        #endregion

        public event Action<ePlayerState> PlayerStateChangedEvent; 
        
        private ePlayerState _State;
        public ePlayerState State
        {
            get => _State;
            set
            {
                _State = value;
                PlayerStateChangedEvent?.Invoke(_State);
            }
        }

        public void Init()
        {
            State = ePlayerState.Normal;
        }
    }
}