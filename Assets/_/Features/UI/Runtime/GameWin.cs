using System;
using UnityEngine;

namespace UIRuntime
{
    public class GameWin : MonoBehaviour
    {

        #region Publics

        //

        #endregion


        #region Unity API

        void Awake()
        {
            CheckGameWin(false);
        }

        #endregion


        #region Main Methods

        public void OnGameWin()
        {
            Debug.Log("On m'appel !!");
            _isActive = !_isActive;
            CheckGameWin(_isActive);
        }

        #endregion


        #region Utils

        /* Fonctions privées utiles */
        void CheckGameWin(bool active)
        {
            Debug.Log("Je test le game win !");
            if (active)
            {
                Debug.Log("Il est actif");
                _GameWinPrefab.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Debug.Log("Il est inactif");
                _GameWinPrefab.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        #endregion


        #region Privates and Protected

        // Variables privées
        [SerializeField] GameObject _GameWinPrefab;
        bool _isActive;

        #endregion
    }
}

