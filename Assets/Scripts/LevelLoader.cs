using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class LevelLoader : MonoBehaviour
    {
        public void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName);
        }

        public void LoadCatchupDay()
        {
            SceneManager.LoadScene("Day_" + PersistentGameInfo.Instance.GetCatchupDay()); 
        }
    }
}