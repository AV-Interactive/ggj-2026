using UnityEngine;
using UnityEngine.SceneManagement;

namespace LevelDesignScript
{
    public class RestartLevel : MonoBehaviour
    {
        public void RestartCurrentLevel()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }

        public void RestartLevelWithName(string nameOfLevel)
        {
            SceneManager.LoadScene(nameOfLevel);
        }
    }
}
