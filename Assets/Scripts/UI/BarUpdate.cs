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
            GameStats.instance.GameStatsChangedEvent += OnGameStatsChangedHandler;
        }

        private void OnGameStatsChangedHandler()
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

        private void OnDisable()
        {
            GameStats.instance.GameStatsChangedEvent -= OnGameStatsChangedHandler;
        }
    }
}