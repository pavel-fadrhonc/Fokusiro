using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Experimental.Input;
using UnityEngine.SceneManagement;
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
            
            var sceneName = SceneManager.GetActiveScene().name;
            var dayStr = sceneName.Substring(sceneName.LastIndexOf('_') + 1);
            int day;
            if (Int32.TryParse(dayStr, out day))
                GameStats.instance.Day = day;
            
            GameEvents.instance.Init();
            GameState.instance.Init();
            PlayerState.instance.Init();

            _streamMovers = new List<StreamMover>(FindObjectsOfType<StreamMover>());
            _itemSpawners = new List<ItemSpawner>(FindObjectsOfType<ItemSpawner>());
        }

        private void Update()
        {
            if (Keyboard.current.leftCtrlKey.isPressed || Keyboard.current.rightCtrlKey.isPressed)
            {
                int day = 0;
                if (Keyboard.current.numpad1Key.wasPressedThisFrame) day = 1;
                if (Keyboard.current.numpad2Key.wasPressedThisFrame) day = 2;
                if (Keyboard.current.numpad3Key.wasPressedThisFrame) day = 3;
                if (Keyboard.current.numpad4Key.wasPressedThisFrame) day = 4;
                if (Keyboard.current.numpad5Key.wasPressedThisFrame) day = 5;
                if (Keyboard.current.numpad6Key.wasPressedThisFrame) day = 6;
                if (Keyboard.current.numpad7Key.wasPressedThisFrame) day = 7;
                if (Keyboard.current.numpad8Key.wasPressedThisFrame) day = 8;
                if (Keyboard.current.numpad9Key.wasPressedThisFrame) day = 9;
                    
                if (day > 0)
                    SceneManager.LoadScene("Day_" + day);
            }
            
            var progress = GameStats.instance.ElapsedTimeInDay / Locator.Instance.ProjectConstants.DayDuration;
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