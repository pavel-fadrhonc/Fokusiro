using UnityEngine.SocialPlatforms;

namespace DefaultNamespace
{
    public class GameManager : SceneSingleton<GameManager>
    {
        protected override void Awake()
        {
            base.Awake();

            GameStats.instance.MaxTime = Locator.Instance.ProjectConstants.MaxTime;
            GameStats.instance.MaxFocus = Locator.Instance.ProjectConstants.MaxFocus;
            GameStats.instance.Time = GameStats.instance.MaxTime;
            GameStats.instance.Focus = GameStats.instance.MaxFocus * Locator.Instance.ProjectConstants.StartFocus;
            
            GameEvents.instance.Init();
        }
    }
}