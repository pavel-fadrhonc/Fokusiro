using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class BarUpdate : MonoBehaviour
    {
        public enum eBarUpdateType
        {
            Time,
            Focus
        }

        public Image fillImage;
        public eBarUpdateType barUpdateType;
        
        private void Awake()
        {
            GameStats.instance.GameStateChangedEvent += OnGameStateChangedHandler;
        }

        private void OnGameStateChangedHandler()
        {
            switch (barUpdateType)
            {
                case eBarUpdateType.Time:
                    fillImage.fillAmount = GameStats.instance.Time / GameStats.instance.MaxTime;
                    break;
                case eBarUpdateType.Focus:
                    fillImage.fillAmount = GameStats.instance.Focus / GameStats.instance.MaxFocus;
                    break;
            }
        }
    }
}