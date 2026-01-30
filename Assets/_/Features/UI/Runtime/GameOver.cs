using System;
using UnityEngine;

namespace UIRuntime
{
    public class GameOver : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        void Awake()
        {
            CheckGameOver(false);
        }

        #endregion


        #region Main Methods

        public void OnGameOver()
        {
            Debug.Log("On m'appel !!");
            _isActive = !_isActive;
            CheckGameOver(_isActive);
        }

        #endregion


        #region Utils

        /* Fonctions privées utiles */
        void CheckGameOver(bool active)
        {
            Debug.Log("Je test le game over !");
            if (active)
            {
                Debug.Log("Il est actif");
                _GameOverPrefab.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Il est inactif");
                _GameOverPrefab.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        #endregion


        #region Privates and Protected

        // Variables privées
        [SerializeField] GameObject _GameOverPrefab;
        bool _isActive;

        #endregion
    }
}

