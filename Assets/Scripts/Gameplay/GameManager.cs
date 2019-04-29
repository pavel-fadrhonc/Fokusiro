using System.Collections.Generic;
using System.IO;
using UnityEngine.SocialPlatforms;

namespace DefaultNamespace
{
    public class GameManager : SceneSingleton<GameManager>
    {
        private List<StreamMover> _streamMovers;
        private List<ItemSpawner> _itemSpawners;
        
        protected override void Awake()
        {
            base.Awake();

            GameStats.instance.MaxTime = Locator.Instance.ProjectConstants.MaxTime;
            GameStats.instance.MaxFocus = Locator.Instance.ProjectConstants.MaxFocus;
            GameStats.instance.Time = GameStats.instance.MaxTime;
            GameStats.instance.Focus = GameStats.instance.MaxFocus * Locator.Instance.ProjectConstants.StartFocus;
            
            GameEvents.instance.Init();
            GameState.instance.Init();
            PlayerState.instance.Init();

            _streamMovers = new List<StreamMover>(FindObjectsOfType<StreamMover>());
            _itemSpawners = new List<ItemSpawner>(FindObjectsOfType<ItemSpawner>());
        }

        private void Update()
        {
            var progress = GameStats.instance.ElapsedTime / Locator.Instance.ProjectConstants.DayDuration;
            var scalingVal = Locator.Instance.ProjectConstants.progressCurve.Evaluate(progress);            
            
            for (int i = 0; i < _streamMovers.Count; i++)
            {
                var sm = _streamMovers[i];
                sm.streamSpeed = scalingVal * sm.startStreamSpeed;
            }

            for (var i = 0; i < _itemSpawners.Count; i++)
            {
                var itemSpawner = _itemSpawners[i];
                itemSpawner.randomSpan = itemSpawner.startRandomSpanTime * (1f / scalingVal);
            }
        }
    }
}