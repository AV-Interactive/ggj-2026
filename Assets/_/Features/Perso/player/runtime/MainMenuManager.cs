using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerRunTime
{
    public class MainMenuManager : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        //

        #endregion


        #region Main Methods

        public void QuitGame (bool Quit)
        {
            Application.Quit();
        }

        public void LoadGame (string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
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

