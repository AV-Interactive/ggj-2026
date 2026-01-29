using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerRunTime
{
    public class UIManager : MonoBehaviour
    {
        #region Publics

        [SerializeField] private GameObject _pauseMenu;
        private bool _onPause = false;

        #endregion

        #region Unity API

        private void Start()
        {
            _pauseMenu.SetActive(false);
        }

        #endregion

        #region Main Methods

        public void PauseGame(bool onPause)
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            _onPause = true;
        }

        public void ResumeGame(bool offPause)
        {
            _pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            _onPause = false;
        }

        public void OnMainMenu(string sceneName)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
        }

        #endregion

        #region Utils

        /* Fonctions privées utiles */

        #endregion

        #region Privates and Protected

        // Variables privées

        #endregion
    }
}

